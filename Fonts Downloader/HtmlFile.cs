using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fonts_Downloader
{
    internal class HtmlFile
    {
        private const string Path = @"C:\FontDownloader";
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
        private const string GoogleFontLinkTemplate = "<link href=\"https://fonts.googleapis.com/css2?family={0}:{1}&display=swap\" rel=\"stylesheet\">";
        private const string FontFamilyStyle = "font-family: {0}, sans-serif;";
        private const string BodyStyle = "body{{\nbackground: #212124;\n{0}\ncolor: #b9b9b9;\n}}";

        public static void DefaultHtml()
        {
            string message = Api.IsInternetAvailable() || Api.IsNetworkAvailable()
                ? "<h3>The program will create a folder named FontDownloader on the C drive to render the fonts.</h3>" +
                  "<h3 style=\"color:#9b2b22;\"> Please select whether you want TTF or WOFF2 files by checking one of the boxes above</h3>"
                : "<h1 style=\"color:#9b2b22;\">Check your internet connection and restart the program</h1>";

            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            string defaultHtml = $@"
                <head>
                    <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap"" rel=""stylesheet"">
                    <style>
                        body {{
                            {string.Format(FontFamilyStyle, "'Roboto'")}
                            color: #b9b9b9 !important;
                            text-align: center !important;
                            background: #212124;
                        }}
                        h1 {{
                            font-weight: 700 !important;
                        }}
                    </style>
                </head>
                <body>
                    <h1>Fonts Downloader </h1>
                    {message}
                </body>";

            using StreamWriter writer = new($"{Path}\\index.html", false);
            writer.WriteLine(defaultHtml);
        }

        public void CreateHtml(string selectedFont, List<string> variants)
        {
            var italicVariants = variants.Select(FontFileStyles.MapVariant)
                                         .Where(v => v.Contains("italic"))
                                         .Select(v => $"1,{v.Replace("italic", "")}")
                                         .ToList();
            var normalVariants = variants.Select(FontFileStyles.MapVariant).Where(m=>!m.Contains("italic")).ToList();

            string italics = string.Join(";", italicVariants);
            string normals = string.Join(";", normalVariants);

            using (StreamWriter writer = new($"{Path}\\index.html", false))
            {
                var htmlContent = GenerateHtmlContent(selectedFont, italics, normals, normalVariants, italicVariants);
                writer.Write(htmlContent);
            }

            italicVariants.Clear();
            normalVariants.Clear();
        }

        private static string GenerateHtmlContent(string selectedFont, string italics, string normals, List<string> normalVariants, List<string> italicVariants)
        {
            var tags = new StringBuilder();
            var styles = new StringBuilder();

            GenerateTags("normal", normalVariants, selectedFont, styles, tags);
            GenerateTags("italic", italicVariants, selectedFont, styles, tags);

            var documentStart = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset =\"UTF-8\">\n<meta name =\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>{selectedFont}</title >\n</head>";
            var googleFontLinkItalics = string.Format(GoogleFontLinkTemplate, selectedFont, $"ital,wght@{italics}");
            var googleFontLinkNormals = string.Format(GoogleFontLinkTemplate, selectedFont, $"wght@{normals}");
            var bodyStyle = string.Format(BodyStyle, $"{string.Format(FontFamilyStyle, $"'{selectedFont}'")}");

            var htmlContent = new StringBuilder();
            htmlContent.AppendLine(documentStart);

            if (!string.IsNullOrEmpty(italics))
                htmlContent.AppendLine(googleFontLinkItalics);

            if (!string.IsNullOrEmpty(normals))
                htmlContent.AppendLine(googleFontLinkNormals);

            htmlContent.AppendLine($"</head>\n<style>\n{bodyStyle}\n{styles.ToString()}")
                .AppendLine(".separator{background: #b9b9b9;\r\nheight: 5px;\r\nborder-radius: 5px;}\n</style>\n<body>")
                .AppendLine($"{tags.ToString()}\n</body>\n</html>");

            return htmlContent.ToString();
        }

        private static void GenerateTags(string variantType, List<string> variants, string selectedFont, StringBuilder styles, StringBuilder tags)
        {
            var FontFileStyles = new FontFileStyles();
            foreach (string variant in variants)
            {
                var fontFileStyle = FontFileStyles.GetFontFileStyles(variant.Replace("1,", ""));
                tags.AppendLine($"<h1 class ='size{variant.Replace("1,", "")}{variantType}'> \n{selectedFont} {variant.Replace("1,", "")} - {variantType} - {fontFileStyle}\n</h1>")
                    .AppendLine($"<p class = 'size{variant.Replace("1,", "")}{variantType}'>\n{LoremIpsum}\n</p>")
                    .AppendLine("<div class = \"separator\"></div>");
                styles.AppendLine($"\nh1.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\n font-stretch: 100% \n}}")
                      .AppendLine($"\np.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\nfont-stretch: 100%;}}");
            }
        }
    }
}
