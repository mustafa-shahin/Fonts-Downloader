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
    internal class HtmlBuilder
    {
        private readonly string _htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FontsWebView.html");
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
        private const string GoogleFontLinkTemplate = "<link href=\"https://fonts.googleapis.com/css2?family={0}:{1}&display=swap\" rel=\"stylesheet\">";

        public void DefaultHtml(bool isConnected = false, WebFonts fonts = null)
        {
            var css = new CssStyle();
            var messageBuilder = new StringBuilder();

            if (fonts?.FontResponse?.Error == null)
            {
                if (isConnected)
                {
                    messageBuilder.Append(
                        new Header(3) { Class = "headers", Text = "Please select whether you want to download TTF or WOFF2 files" }.RenderElement());
                }
                else
                {
                    messageBuilder.Append(
                        new Header(1) { Class = "headers", Text = "Check your internet connection and restart the program" }.RenderElement() +
                        new Header(2) { Text = "Click on the image to refresh" }.RenderElement());
                }
            }
            else
            {
                messageBuilder.Append(
                    new Header(1) { Class = "headers", Text = fonts.FontResponse.Error.Message }.RenderElement());
            }

            var headerFontsLink = "<link href=\"https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap\" rel=\"stylesheet\">";

            css.Properties["body"] = new Dictionary<string, string>
            {
                { "font-family", "'Roboto', 'sans-serif'" },
                { "color", "#b9b9b9" },
                { "text-align", "center !important" },
                { "margin", "0" },
                { "padding", "20px" },
                { "background-color", "#1e1e1e" }
            };

            css.Properties[".headers"] = new Dictionary<string, string>
            {
                { "color", "#9b2b22" },
                { "margin-bottom", "20px" }
            };

            css.Properties["h1"] = new Dictionary<string, string>
            {
                { "font-size", "2.5em" },
                { "margin-bottom", "30px" }
            };

            using StreamWriter writer = new(_htmlPath, false);
            messageBuilder.Insert(0, new Header(1) { Text = "Google Fonts Downloader" }.RenderElement());

#if DEBUG
            writer.Write(RenderBody(messageBuilder.ToString(), css.Render(), headerFontsLink));
#else
            writer.Write(Uglify.Html(RenderBody(messageBuilder.ToString(), css.Render(), headerFontsLink)).Code);
#endif

            writer.Close();
        }

        public void CreateHtml(Item selectedFont)
        {
            var css = new CssStyle();
            if (selectedFont is null || selectedFont.Variants is null || selectedFont.Variants.Count == 0)
            {
                return;
            }

            var allVariants = selectedFont.Variants
                .Select(m => m == "regular" || m == "italic" ? Helper.MapVariant(m) : m)
                .GroupBy(v => v.Contains("italic"))
                .SelectMany(g => g.Key
                    ? g.Select(v => $"1,{v.Replace("italic", "")}")
                    : g.Select(v => $"0,{v}"))
                .ToArray();

            var weights = string.Join(";", allVariants);
            var googleFontLink = string.Format(GoogleFontLinkTemplate, selectedFont.Family, $"ital,wght@{weights.Replace(" ", "")}");

            // Add scrollbar styling
            css.Properties["::-webkit-scrollbar"] = new Dictionary<string, string>
            {
                {"width", "10px" }
            };

            css.Properties["::-webkit-scrollbar-thumb"] = new Dictionary<string, string>
            {
                { "background" , "#003f5b" },
                {"border-radius", "100vw" }
            };

            css.Properties["::-webkit-scrollbar-track"] = new Dictionary<string, string>
            {
                { "background" , "#28292a" },
                {"border-radius", "100vw" },
                {"margin-block", ".5em" }
            };

            css.Properties["body"] = new Dictionary<string, string>
            {
                { "background-color", "#1e1e1e" },
                { "color", "#e0e0e0" },
                { "padding", "20px" },
                { "font-family", "system-ui, -apple-system, sans-serif" },
                { "margin", "0" }
            };

            using StreamWriter writer = new(_htmlPath, false);
            string htmlContent = string.Concat(CreateHtmlContents(selectedFont, css).SelectMany(m => m.RenderElement()));

#if DEBUG
            writer.Write(RenderBody(htmlContent, css.Render(), googleFontLink));
#else
            writer.Write(Uglify.Html(RenderBody(htmlContent, css.Render(), googleFontLink)).Code);
#endif

            writer.Close();
        }

        private List<HtmlElements> CreateHtmlContents(Item selectedFont, CssStyle css)
        {
            var htmlElements = new List<HtmlElements>();
            var counter = 0;

            // List of colors to cycle through
            var Colors = new List<string> {
                "#005B41", "#1E5128", "#144272", "#1F6E8C", "#5C8374",
                "#183D3D", "#03C988", "#77B0AA", "#A12568", "#3B185F",
                "#78A083", "#346751", "#7B113A", "#003F5C", "#363062",
                "#3E3232", "#83142C", "#77B0AA"
            };

            string fontName = WebUtility.UrlEncode(selectedFont.Family).Replace("%20", "+");

            css.Properties["a"] = new Dictionary<string, string>
            {
                { "text-align","center" },
                { "width", "100%" },
                { "display", "block" },
                { "color","#b9b9b9" },
                { "text-decoration","none" },
                { "font-family", selectedFont.Family },
                { "padding", "10px" },
                { "background-color", "#2d2d2d" },
                { "border-radius", "5px" },
                { "margin", "20px 0" },
                { "transition", "background-color 0.3s ease" }
            };

            css.Properties["a:hover"] = new Dictionary<string, string>
            {
                { "background-color", "#3d3d3d" }
            };

            var header = new Header(1)
            {
                Text = selectedFont.Family,
                Style = "font-family: " + selectedFont.Family + "; margin-bottom: 20px; color: white;"
            };

            var anchor = new Anchor
            {
                Href = $"https://fonts.google.com/specimen/{fontName}?query={fontName.ToLower()}",
                Text = "Click Here to See it on Google Fonts"
            };

            htmlElements.Add(header);
            htmlElements.Add(anchor);

            foreach (var variant in selectedFont.Variants)
            {
                var color = Colors[counter % Colors.Count];
                var variantType = variant.Contains("italic") ? "italic" : "normal";
                var className = $"{selectedFont.Family.Replace(" ", "-")}-{variant.Replace(" italic", "")}-{variantType}";
                var fontFileStyle = Helper.GetFontFileStyles(variant);
                var title = $"{selectedFont.Family + $" {Helper.MapVariant(variant).Replace("italic", "")}"} - {char.ToUpper(variantType[0]) + variantType[1..]} - {fontFileStyle}";

                var container = new Div { Class = $"container{counter}" };
                container.Children.Add(new Header(1) { Class = className, Text = title });
                container.Children.Add(new Paragraph { Class = className, Text = LoremIpsum });
                htmlElements.Add(container);

                if (counter == 0)
                {
                    css.Properties["h1"] = new Dictionary<string, string>
                    {
                        { "font-family", selectedFont.Family },
                        { "font-style", variantType },
                        { "font-weight", variant.Replace("italic", "") },
                        { "font-stretch", "100%" },
                        { "color", "white" },
                        { "text-align", "center" },
                        { "margin-bottom", "0px" }
                    };
                }

                css.Properties[$".{className}"] = new Dictionary<string, string>
                {
                    { "font-family", selectedFont.Family },
                    { "font-style", variantType },
                    { "font-weight", variant.Replace("italic", "") },
                    { "font-stretch", "100%" },
                    { "color", "white" }
                };

                css.Properties[$".container{counter}"] = new Dictionary<string, string>
                {
                    { "background", color },
                    { "padding", "20px 25px" },
                    { "border-radius", "15px" },
                    { "font-stretch", "100%" },
                    { "margin", "20px 0" },
                    { "box-shadow", "0 4px 6px rgba(0, 0, 0, 0.1)" },
                    { "transition", "transform 0.2s ease" }
                };

                css.Properties[$".container{counter}:hover"] = new Dictionary<string, string>
                {
                    { "transform", "translateY(-5px)" }
                };

                counter++;
            }
            css.Properties["body"] = new Dictionary<string, string>
            {
                { "background-color", "#1e1e1e" },
                { "font-family", "system-ui, -apple-system, BlinkMacSystemFont, sans-serif" },
                { "padding", "20px" },
                { "line-height", "1.6" },
                { "color", "#f0f0f0" }
            };

            return htmlElements;
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