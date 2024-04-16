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
        private static readonly string HtmlPath = AppDomain.CurrentDomain.BaseDirectory + "/index.html";
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
        private const string GoogleFontLinkTemplate = "<link href=\"https://fonts.googleapis.com/css2?family={0}:{1}&display=swap\" rel=\"stylesheet\">";
        private const string DocumentStart = "<!DOCTYPE html>\n<html lang=\"en\">\n<head>\n<meta charset =\"UTF-8\">\n<meta name =\"viewport\" content=\"width=device-width, initial-scale=1.0\">";
        public static void DefaultHtml(Root Error = null)
        {
            string message;
            if (Error is null)
            {
                message = (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
                           ? "<h3 style=\"color:#9b2b22;\"> Please select whether you want to download TTF or WOFF2 files</h3>"
                              : "<h1 style=\"color:#9b2b22;\">Check your internet connection and restart the program</h1>\n<h2>Click on the image to refresh</h2>";
            }
            else
                message = $"<html><body style=\" background: #212124;\">\n<h1 style=\"color:#9b2b22;text-align: center;\">{Error.Error.Message}</h1>\n</body>\n</html>";


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
            using StreamWriter writer = new(HtmlPath, false);
#if DEBUG
            writer.Write(defaultHtml);
#else
            writer.WriteLine(Uglify.Html(defaultHtml));
#endif
        }
        public static void CreateHtml(Item selectedFont)
        {
            if (selectedFont is null || selectedFont.Variants is null || !selectedFont.Variants.Any())
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

            var documentStart = $"{DocumentStart}\n<title>{selectedFont.Family}</title >\n</head>";
            var GoogleFontLink = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"ital,wght@{string.Join(";", AllVariants.Where(m => m.StartsWith("1,")))}")
                                        + "\n" + string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"wght@{string.Join(";", AllVariants.Where(m => !m.StartsWith("1,")))}");

            var BodyStyle = $"body{{\nbackground: #212124;\ncolor: #b9b9b9;\n" + $"font-family:\"{selectedFont.Family}\"}}";


            HtmlContent.AppendLine(documentStart);

            GenerateTags(selectedFont, Styles, Tags);
            if (!string.IsNullOrEmpty(GoogleFontLink))
                HtmlContent.AppendLine(GoogleFontLink);

            HtmlContent.AppendLine($"</head>\n<style>\n{BodyStyle}\n{Styles.ToString()}")
                .AppendLine(".separator{background: #b9b9b9;\r\nheight: 5px;\r\nborder-radius: 5px;}\n</style>\n<body>")
                .AppendLine($"{Tags.ToString()}\n</body>\n</html>");

            using StreamWriter writer = new(HtmlPath, false);

#if DEBUG
            writer.Write(HtmlContent);
#else
            writer.WriteLine(Uglify.Html(HtmlContent.ToString()));   
#endif


        }
        private static void GenerateTags(Item selectedFont, StringBuilder styles, StringBuilder tags)
        {
            var Colors = new List<string> { "#58A399", "#77B0AA", "#144272", "#1F6E8C", "#5C8374", "#183D3D", "#03C988", "#1E5128", "#A12568", "#3B185F", "#78A083", "#346751", "#7B113A", "#003F5C", "#363062", "#3E3232", "#83142C", "#005B41" };
            Colors = Shuffle(Colors);
            var counter = 0;
            foreach (var variant in selectedFont.Variants)
            {
                var Color = Colors[0];
                Colors.RemoveAt(0);               
                var VariantType = variant.Contains("italic") ? "italic" : "normal";
                var ClassName = $"size{variant.Replace("italic", "")}{VariantType}";              
                var FontFileStyle = Helper.GetFontFileStyles(Helper.MapVariant(variant));
                var Title = $"{selectedFont.Family + $" {Helper.MapVariant(variant).Replace("italic", "")}"} - {char.ToUpper(VariantType[0]) + VariantType[1..]} - {FontFileStyle}";
                tags.AppendLine($"<div class = \"container{counter}\">")
                    .Append($"<h1 class ='{ClassName}'> \n{Title}\n</h1>")
                    .AppendLine($"<p class = '{ClassName}'>\n{LoremIpsum}\n</p></div>")
                    .AppendLine("<div class = \"separator\"></div>");
                styles.AppendLine($"\nh1.{ClassName}{{\nfont-family: '{selectedFont.Family}';\nfont-style: {VariantType};\nfont-weight: {variant.Replace("italic", "")};\n font-stretch: 100%; \n color: white;\n}}")
                      .AppendLine($"\np.{ClassName}{{\nfont-family: '{selectedFont.Family}';\nfont-style: {VariantType};\nfont-weight: {variant.Replace("italic", "")};\nfont-stretch: 100%; color: white;\n}}")
                      .AppendLine($"\n.container{counter}{{\nbackground: {Color};\n     padding: 10px 15px;\n    border-radius: 15px;\n       margin: 10px 0;\n}}");
                counter++;
            }

        }
        private static List<T> Shuffle<T>(List<T> list)
        {
            var rng = new Random();
            var n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }

    }
}
