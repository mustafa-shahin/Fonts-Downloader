using NUglify.Html;
using NUglify;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;

namespace Fonts_Downloader
{
    internal class HtmlFile
    {
        private const string Path = @"C:\FontDownloader";
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
        private const string GoogleFontLinkTemplate = "<link href=\"https://fonts.googleapis.com/css2?family={0}:{1}&display=swap\" rel=\"stylesheet\">";
        private const string DocumentStart = "<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset =\"UTF-8\">\n<meta name =\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
        public static void DefaultHtml(Root Error = null)
        {
            string message;
            if (Error is null)
            {
                message = (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
                           ? "<h3>The program will create a folder named FontDownloader on the C drive to render the fonts.</h3>" +
                            "<h3 style=\"color:#9b2b22;\"> Please select whether you want TTF or WOFF2 files by checking one of the boxes above</h3>"
                              : "<h1 style=\"color:#9b2b22;\">Check your internet connection and restart the program</h1>\n<h2>Click on the image to refresh</h2>";
            }
            else
                message = $"<html><body style=\" background: #212124;\">\n<h1 style=\"color:#9b2b22;text-align: center;\">{Error.Error.Message}</h1>\n</body>\n</html>";

            if (!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            string defaultHtml = $@"{DocumentStart}
                                    <title>Google Fonts Downloader</title >
                    <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap"" rel=""stylesheet"">
                    <style>
                        body {{
                            font-family: 'Roboto', 'sans-serif';
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
                    <h1>Google Fonts Downloader </h1>
                    {message}
                </body>";
            using StreamWriter writer = new($"{Path}\\index.html", false);
#if DEBUG
            writer.Write(defaultHtml);
#else
            writer.WriteLine(Uglify.Html(defaultHtml));
#endif


        }
        public static void CreateHtml(Item selectedFont)
        {
            var tags = new StringBuilder();
            var styles = new StringBuilder();

            var italicVariants = selectedFont.Variants.Select(Helper.MapVariant)
                                  .Where(v => v.Contains("italic"))
                                  .Select(v => $"1,{v.Replace("italic", "")}")
                                  .ToArray();
            var normalVariants = selectedFont.Variants.Select(Helper.MapVariant).Where(m => !m.Contains("italic")).ToArray();

            var documentStart = $"{DocumentStart}\n<title>{selectedFont}</title >\n</head>";
            var googleFontLinkItalics = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"ital,wght@{string.Join(";", italicVariants)}");
            var googleFontLinkNormals = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"wght@{string.Join(";", normalVariants)}");
            var bodyStyle = $"body{{\nbackground: #212124;\ncolor: #b9b9b9;\n" + $"font-family:\"{selectedFont.Family}\"}}";

            var htmlContent = new StringBuilder();
            htmlContent.AppendLine(documentStart);

            if (normalVariants.Any())
            {
                htmlContent.AppendLine(googleFontLinkNormals);
                GenerateTags("normal", normalVariants, selectedFont.Family, styles, tags);
            }
            if (italicVariants.Any())
            {
                htmlContent.AppendLine(googleFontLinkItalics);
                GenerateTags("italic", italicVariants, selectedFont.Family, styles, tags);
            }

            htmlContent.AppendLine($"</head>\n<style>\n{bodyStyle}\n{styles.ToString()}")
                .AppendLine(".separator{background: #b9b9b9;\r\nheight: 5px;\r\nborder-radius: 5px;}\n</style>\n<body>")
                .AppendLine($"{tags.ToString()}\n</body>\n</html>");

            using StreamWriter writer = new($"{Path}\\index.html", false);

#if DEBUG
            writer.Write(htmlContent);
#else
            writer.WriteLine(Uglify.Html(htmlContent.ToString()));   
#endif
        }
        private static void GenerateTags(string variantType, string[] variants, string selectedFont, StringBuilder styles, StringBuilder tags)
        {
            foreach (string variant in variants)
            {
                var fontFileStyle = Helper.GetFontFileStyles(variant.Replace("1,", ""));
                tags.AppendLine($"<h1 class ='size{variant.Replace("1,", "")}{variantType}'> \n{selectedFont} {variant.Replace("1,", "")} - {variantType} - {fontFileStyle}\n</h1>")
                    .AppendLine($"<p class = 'size{variant.Replace("1,", "")}{variantType}'>\n{LoremIpsum}\n</p>")
                    .AppendLine("<div class = \"separator\"></div>");
                styles.AppendLine($"\nh1.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\n font-stretch: 100% \n}}")
                      .AppendLine($"\np.size{variant.Replace("1,", "")}{variantType}{{\nfont-family: '{selectedFont}';\nfont-style: {variantType};\nfont-weight: {variant.Replace("1,", "")};\nfont-stretch: 100%;}}");
            }
        }
    }
}
