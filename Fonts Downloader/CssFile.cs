using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        private readonly Dictionary<string, string> FontFileStyles = new Dictionary<string, string>
        {
            { "100", "Thin" },{ "200", "ExtraLight" },
            { "300", "Light" },{ "400", "Regular" },
            { "500", "Medium" },{ "600", "SemiBold" },
            { "700", "Bold" },{ "800", "ExtraBold" },
            { "900", "Black" },
        };

        private readonly List<string> Styles = new List<string>();
        private readonly List<string> FontWeight = new List<string>();

        public void CreateCSS(List<string> variants, string folderName, string fontName, bool minify, List<string> subsets = null)
        {
            var cssList = GenerateCssList(variants, fontName, subsets);

            if (cssList.Any())
            {
                string fontFolder = Path.Combine(folderName, fontName.Replace(" ", ""));
                Directory.CreateDirectory(fontFolder);

                string cssFilePath = Path.Combine(fontFolder, $"{fontName.Replace(" ", "")}{(minify ? ".min" : "")}.css");
                string cssContent = string.Join("\n", cssList);

                if (minify)
                {
                    var minifier = new Minifier();
                    cssContent = minifier.MinifyStyleSheet(cssContent);
                }

                File.WriteAllText(cssFilePath, cssContent);
            }
        }

        private List<string> GenerateCssList(List<string> variants, string fontName, List<string> subsets)
        {
            var cssList = new List<string>();

            foreach (var variant in variants)
            {
                if (ParseCheckedItem(variant, out var fontStyle, out var fontWeight))
                {
                    Styles.Add(fontStyle);
                    FontWeight.Add(fontWeight);
                    string fontFileStyle = FontFileStyles[fontWeight];

                    foreach (var subset in subsets ?? Enumerable.Empty<string>())
                    {
                        var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, fontFileStyle, subset.ToLower());
                        cssList.Add(css);
                    }
                }
            }
            return cssList;
        }

        private bool ParseCheckedItem(string checkedItem, out string fontStyle, out string fontWeight)
        {
            fontStyle = checkedItem.Contains("italic") ? "italic" : "normal";
            fontWeight = checkedItem.Replace("italic", "").Trim();

            return !string.IsNullOrWhiteSpace(fontWeight) && FontFileStyles.TryGetValue(fontWeight, out _);
        }

        private string GenerateFontFaceCss(string fontName, string fontStyle, string fontWeight, string fontFileStyle, string subset = null)
        {
            var subsetComment = !string.IsNullOrWhiteSpace(subset) ? $"/*{subset}*/\n" : "";
            return $"{subsetComment}" +
                   $"@font-face {{\n" +
                   $"font-family: '{fontName}';\n" +
                   $"font-style: {fontStyle};\n" +
                   $"font-weight: {fontWeight};\n" +
                   $"font-stretch: 100%;\n" +
                   $"src: url('{FontFileName(fontName, fontStyle, fontFileStyle)}.ttf')\n}}";
        }

        private string FontFileName(string fontName, string fontStyle, string fontWeight)
        {
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontWeight}";
        }
    }
}
