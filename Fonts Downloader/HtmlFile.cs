using NUglify.Html;
using NUglify;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System;
using Microsoft.VisualBasic;

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
            if(selectedFont is null || selectedFont.Variants is null || !selectedFont.Variants.Any())
            {
                return; 
            }
            var Tags = new StringBuilder();
            var Styles = new StringBuilder();
            var HtmlContent = new StringBuilder();
            var AllVariants = selectedFont.Variants
                              .Select(Helper.MapVariant)
                              .GroupBy(v => v.Contains("italic"))
                              .SelectMany(g => g.Key ? g.Select(v => $"1,{v.Replace("italic", "")}") : [.. g])
                              .ToArray();
           
                var documentStart = $"{DocumentStart}\n<title>{selectedFont}</title >\n</head>";
                var GoogleFontLink = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"ital,wght@{string.Join(";", AllVariants.Where(m => m.StartsWith("1,")))}")
                                            + "\n" + string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"wght@{string.Join(";", AllVariants.Where(m => !m.StartsWith("1,")))}");

                var BodyStyle = $"body{{\nbackground: #212124;\ncolor: #b9b9b9;\n" + $"font-family:\"{selectedFont.Family}\"}}";

              
                HtmlContent.AppendLine(documentStart);

                GenerateTags(AllVariants, selectedFont.Family, Styles, Tags);
                if(!string.IsNullOrEmpty(GoogleFontLink))
                    HtmlContent.AppendLine(GoogleFontLink);

                HtmlContent.AppendLine($"</head>\n<style>\n{BodyStyle}\n{Styles.ToString()}")
                    .AppendLine(".separator{background: #b9b9b9;\r\nheight: 5px;\r\nborder-radius: 5px;}\n</style>\n<body>")
                    .AppendLine($"{Tags.ToString()}\n</body>\n</html>");

                using StreamWriter writer = new($"{Path}\\index.html", false);

#if DEBUG
                writer.Write(HtmlContent);
#else
            writer.WriteLine(Uglify.Html(htmlContent.ToString()));   
#endif
            

        }
        private static void GenerateTags(string[] variants, string selectedFont, StringBuilder styles, StringBuilder tags)
        {
            foreach (string variant in variants)
            {
                string VariantType = variant.Contains("1,") ? "italic" : "normal";
                var fontFileStyle = Helper.GetFontFileStyles(variant.Replace("1,", ""));
                tags.AppendLine($"<h1 class ='size{variant.Replace("1,", "")}{VariantType}'> \n{selectedFont} {variant.Replace("1,", "")} - {VariantType} - {fontFileStyle}\n</h1>")
                    .AppendLine($"<p class = 'size{variant.Replace("1,", "")}{VariantType}'>\n{LoremIpsum}\n</p>")
                    .AppendLine("<div class = \"separator\"></div>");
                styles.AppendLine($"\nh1.size{variant.Replace("1,", "")}{VariantType}{{\nfont-family: '{selectedFont}';\nfont-style: {VariantType};\nfont-weight: {variant.Replace("1,", "")};\n font-stretch: 100% \n}}")
                      .AppendLine($"\np.size{variant.Replace("1,", "")}{VariantType}{{\nfont-family: '{selectedFont}';\nfont-style: {VariantType};\nfont-weight: {variant.Replace("1,", "")};\nfont-stretch: 100%;}}");
            }
        }
    }
}
