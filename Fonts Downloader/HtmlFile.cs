using NUglify.Html;
using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class HtmlFile
    {
        private static readonly string HtmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FontsWebView.html");
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
        private const string GoogleFontLinkTemplate = "<link href=\"https://fonts.googleapis.com/css2?family={0}:{1}&display=swap\" rel=\"stylesheet\">";

        public static void DefaultHtml(WebFonts fonts = null)
        {
            var Css = new CssStyle();
            string message = string.Empty;

            if (fonts?.FontResponse?.Error == null)
            {
                message = (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
                    ? new Header(3) { Class = "headers", Text = "Please select whether you want to download TTF or WOFF2 files" }.RenderElement()
                    : new Header(1) { Class = "headers", Text = "Check your internet connection and restart the program" }.RenderElement()
                      + new Header(2) { Text = "Click on the image to refresh" }.RenderElement();
            }
            else
            {
                message = new Header(1) { Class = "headers", Text = fonts.FontResponse.Error.Message }.RenderElement();
            }

            var headerFontsLink = "<link href=\"https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap\" rel=\"stylesheet\">";

            Css.Properties["body"] = new Dictionary<string, string>
                        {
                            { "font-family", "'Roboto', 'sans-serif'" },
                            { "color", "#b9b9b9" },
                            { "text-align", "center !important" }
                        };
            Css.Properties[".headers"] = new Dictionary<string, string>
                        {
                            { "color", "#9b2b22" },
                        };
            using StreamWriter writer = new(HtmlPath, false);
            message = new Header(1) { Text = "Google Fonts Downloader" }.RenderElement() + message;

#if DEBUG
            writer.Write(RenderBody(message, Css.Render(), headerFontsLink));

#else
                writer.Write(Uglify.HtmlToText(RenderBody(message, Css.Render(), headerFontsLink)));
#endif

        }
        public static void CreateHtml(Item selectedFont)
        {
            var Css = new CssStyle();
            if (selectedFont is null || selectedFont.Variants is null || selectedFont.Variants.Count == 0)
            {
                return;
            }
            var Tags = new StringBuilder();
            var Styles = new StringBuilder();
            var allVariants = selectedFont.Variants
                                          .Select(m => m == "regular" || m == "italic" ? Helper.MapVariant(m) : m)
                                          .GroupBy(v => v.Contains("italic"))
                                          .SelectMany(g => g.Key
                                                              ? g.Select(v => $"1,{v.Replace("italic", "")}")
                                                              : g.Select(v => $"0,{v}"))
                                          .ToArray();
            var weights = string.Join(";", allVariants);
            var GoogleFontLink = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"ital,wght@{weights.Replace(" ", "")}");
            Css.Properties["::-webkit-scrollbar"] = new Dictionary<string, string>
            {
                {"width", "10px" }
            };
            Css.Properties["::-webkit-scrollbar-thumb"] = new Dictionary<string, string>
            {
                { "background" , "#003f5b" },
                {"border-radius", "100vw" }

            };
            Css.Properties["::-webkit-scrollbar-track"] = new Dictionary<string, string>
            {
                { "background" , "#28292a" },
                {"border-radius", "100vw" },
                {"margin-block", ".5em" }
            };
            Styles.AppendLine(Css.Render());
            using StreamWriter writer = new(HtmlPath, false);
            CreateHtmlContent(selectedFont, Tags, Styles, Css);

#if DEBUG
            writer.Write(RenderBody(Tags.ToString(), Styles.ToString(), GoogleFontLink));
#else
           writer.Write(Uglify.Html(RenderBody(Tags.ToString(), Styles.ToString(), GoogleFontLink)));
#endif
        }

        private static void CreateHtmlContent(Item selectedFont, StringBuilder tags, StringBuilder styles, CssStyle css)
        {
            var counter = 0;
            var Colors = new List<string> { "#58A399", "#77B0AA", "#144272", "#1F6E8C", "#5C8374", "#183D3D", "#03C988", "#1E5128", "#A12568", "#3B185F", "#78A083", "#346751", "#7B113A", "#003F5C", "#363062", "#3E3232", "#83142C", "#005B41" };
            Colors = Shuffle(Colors);
            string FontName = WebUtility.UrlEncode(selectedFont.Family).Replace("%20", "+");
            css.Properties["a"] = new Dictionary<string, string>
            {
                { "text-align","center" },
                { "width", "100%" },
                { "display", "block" },
                { "color","#b9b9b9" },
                { "text-decoration","none" },
                { "font-family", selectedFont.Family }
            };
            tags.AppendLine(new Header(1) { Text = selectedFont.Family }.RenderElement())
                .AppendLine(new Aanker
                {
                    Href = $"https://fonts.google.com/specimen/{FontName}?query={FontName.ToLower()}",
                    Text = "Click Here to See it on Google Fonts"
                }.RenderElement()
                );
            foreach (var variant in selectedFont.Variants)
            {
                var Color = Colors[0];
                Colors.RemoveAt(0);
                var VariantType = variant.Contains("italic") ? "italic" : "normal";
                var ClassName = $"{selectedFont.Family.Replace(" ", "-")}-{variant.Replace(" italic", "")}-{VariantType}";
                var FontFileStyle = Helper.GetFontFileStyles(variant);
                var Title = $"{selectedFont.Family + $" {Helper.MapVariant(variant).Replace("italic", "")}"} - {char.ToUpper(VariantType[0]) + VariantType[1..]} - {FontFileStyle}";
                var container = new Div { Class = $"container{counter}" };
                container.Children.Add(new Header(1) { Class = ClassName, Text = Title });
                container.Children.Add(new Paragraph { Class = ClassName, Text = LoremIpsum });
                tags.AppendLine(container.RenderElement())
                    .AppendLine(counter < selectedFont.Variants.Count - 1 ? new Div { Class = "separator" }.RenderElement() : "");
                if (counter == 0)
                {
                    css.Properties["h1"] = new Dictionary<string, string>
                    {

                        { "font-family", selectedFont.Family },
                        { "font-style", VariantType },
                        { "font-weight", variant.Replace("italic", "") },
                        { "font-stretch", " 100%" },
                        { "color", " white" },
                        { "text-align", "center" },
                        { "margin-bottom", "0px" }
                    };
                }

                css.Properties[$".{ClassName}"] = new Dictionary<string, string>
                {
                    { "font-family", selectedFont.Family },
                    { "font-style", VariantType },
                    { "font-weight", variant.Replace("italic", "") },
                    { "font-stretch", " 100%" },
                    { "color", " white" }
                };

                css.Properties[$".container{counter}"] = new Dictionary<string, string>
                {
                    { "background", Color },
                    { "padding", "10px 15px" },
                    { "border-radius", "15px" },
                    { "font-stretch", " 100%" },
                    { "margin", " 10px 0" }
                };
                css.Properties[$".separator"] = new Dictionary<string, string>
                {
                    { "background", "#b9b9b9" },
                    { "height", "5px" },
                    { "border-radius", "5px" },
                    { "font-stretch", " 100%" },
                    { "margin", " 10px 0" }
                };

                counter++;
            }
            styles.AppendLine(css.Render());
        }
        private static List<T> Shuffle<T>(List<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
            return list;
        }
        private static string RenderBody(string body, string styles = null, string headerFontsLink = null)
        {
            return $@"<!DOCTYPE html>
                                    <html lang=""en"">
                                    <head>
                                    <meta charset=""UTF-8"">
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                    <title>Google Fonts Downloader</title>
                                    {headerFontsLink}
                                    <style>{styles}</style>
                                    </head>
                                    <body>
                                    {body}
                                    </body>
                                    </html>";
        }
    }
}