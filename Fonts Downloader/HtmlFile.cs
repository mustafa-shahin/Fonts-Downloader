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
                            font-family: 'Roboto', sans-serif;
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
            var italicVariants = new List<string>();
            var normalVariants = new List<string>();

            foreach (var variant in variants)
            {
                if (!variant.Contains("italic"))
                    normalVariants.Add(variant);
                else
                    italicVariants.Add($"1,{variant.Replace("italic", "")}");
            }

            string italics = string.Join(";", italicVariants);
            string normals = string.Join(";", normalVariants);

            string googleFontLinkItalics = $"<link href=\"https://fonts.googleapis.com/css2?family={selectedFont}:ital,wght@{italics}&display=swap\" rel=\"stylesheet\">";
            string googleFontLinkNormals = $"<link href=\"https://fonts.googleapis.com/css2?family={selectedFont}:wght@{normals}&display=swap\" rel=\"stylesheet\">";
            string fontFamilyStyle = $"font-family: '{selectedFont}', sans-serif;";
            string bodyStyle = $"body{{\nbackground: #212124;\n{fontFamilyStyle}\ncolor: #b9b9b9;\n}}";

            var pTagCSS = new List<string>();
            var pTags = new List<string>();
            var h1Tags = new List<string>();
            var h1TagsCSS = new List<string>();

            GenerateTags("normal", normalVariants, selectedFont, pTagCSS, pTags, h1TagsCSS, h1Tags);
            GenerateTags("italic", italicVariants, selectedFont, pTagCSS, pTags, h1TagsCSS, h1Tags);

            using (StreamWriter writer = new($"{Path}\\index.html", false))
            {
                var htmlContent = new StringBuilder();
                var documentStart = $"<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset =\"UTF-8\">\n<meta name =\"viewport\" content=\"width=device-width, initial-scale=1.0\">\n<title>{selectedFont}</title >\n</head>";
                htmlContent.AppendLine(documentStart);

                if (!string.IsNullOrEmpty(italics))
                    htmlContent.AppendLine(googleFontLinkItalics);

                if (!string.IsNullOrEmpty(normals))
                    htmlContent.AppendLine(googleFontLinkNormals);

                htmlContent.AppendLine("</head>");
                htmlContent.AppendLine($"<style>\n{bodyStyle}");

                for (int i = 0; i < pTagCSS.Count; i++)
                {
                    htmlContent.AppendLine(pTagCSS[i]);
                    htmlContent.AppendLine(h1TagsCSS[i]);

                    if (i == pTagCSS.Count - 1)
                    {
                        htmlContent.AppendLine(".separator{background: #b9b9b9;\r\nheight: 5px;\r\nborder-radius: 5px;}");
                        htmlContent.AppendLine("</style>");
                    }
                }
                htmlContent.AppendLine("<body>");
                foreach (var (h1Tag, pTag) in h1Tags.Zip(pTags, (h1, p) => (h1, p)))
                {                
                    htmlContent.AppendLine($"{h1Tag}\n{pTag}");
                    htmlContent.AppendLine("<div class=\"separator\"></div>");
                }

                htmlContent.AppendLine("</body>\n</html>");


                writer.Write(htmlContent.ToString());
            }
            italicVariants.Clear();
            normalVariants.Clear();
        }

        private static void GenerateTags(string variantType, List<string> variants, string selectedFont, List<string> pTagCSS, List<string> pTags, List<string> h1TagsCSS, List<string> h1Tags)
        {
            var FontFileStyles = new FontFileStyles();
            foreach (string variant in variants)
            {
                var fontFileStyle = FontFileStyles.GetFontFileStyles(variant.Replace("1,", ""));
                string pTagStyle = $"\np.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\nfont-stretch: 100%;}}";
                pTagCSS.Add(pTagStyle);

                string paragraph = $"<p class = 'size{variant.Replace("1,", "")}{variantType}'>\n{LoremIpsum}\n</p>";
                pTags.Add(paragraph);

                string h1TagStyle = $"\nh1.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\n font-stretch: 100% \n}}";
                h1TagsCSS.Add(h1TagStyle);

                string h1Tag = $"<h1 class = 'size{variant.Replace("1,", "")}{variantType}'> \n{selectedFont} {variant.Replace("1,", "")} - {fontFileStyle}\n</h1>";
                h1Tags.Add(h1Tag);
            }
        }
    }
}
