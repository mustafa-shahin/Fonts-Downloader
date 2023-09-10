using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        private readonly Dictionary<string, string> FontFileStyles = new Dictionary<string, string>
        {
            { "100", "Thin" }, { "200", "ExtraLight" },
            { "300", "Light" }, { "400", "Regular" },
            { "500", "Medium" }, { "600", "SemiBold" },
            { "700", "Bold" }, { "800", "ExtraBold" },
            { "900", "Black" },
        };

        public void CreateCSS(IEnumerable<string> variants, string folderName, string fontName, bool minify=false, IEnumerable<string> subsets = null)
        {
            if (variants == null || !variants.Any() || string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(folderName))
            {
                string missingParameters = string.Join(", ",
                    (variants == null || !variants.Any()) ? "Items" : "",
                    string.IsNullOrEmpty(fontName) ? "SelectedFont" : "",
                    string.IsNullOrEmpty(folderName) ? "FolderName" : "");
                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }

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

        private List<string> GenerateCssList(IEnumerable<string> variants, string fontName, IEnumerable<string> subsets = null)
        {
            var cssList = new List<string>();

            foreach (var variant in variants)
            {
                if (ParseCheckedItem(variant, out var fontStyle, out var fontWeight) &&
                    FontFileStyles.TryGetValue(fontWeight, out var fontFileStyle))
                {
                    if (subsets != null && (subsets.Any() || subsets != null))
                    {
                        foreach (var subset in subsets)
                        {
                            var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, fontFileStyle, subset.ToLower());
                            cssList.Add(css);
                        }
                    }
                    else
                    {
                        var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, fontFileStyle);
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

            return !string.IsNullOrWhiteSpace(fontWeight);
        }

        private string GenerateFontFaceCss(string fontName, string fontStyle, string fontWeight, string fontFileStyle=null, string subset = null)
        {
            if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(fontStyle) || string.IsNullOrEmpty(fontWeight))
            {
                string missingParameters = string.Join(", ",
                    (string.IsNullOrEmpty(fontName)) ? "Font's name" : "",
                    string.IsNullOrEmpty(fontStyle) ? "Font's style" : "",
                    string.IsNullOrEmpty(fontWeight) ? "Font's weight" : "");
                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
            var subsetComment = !string.IsNullOrEmpty(subset) ? $"/*{subset}*/\n" : "";
            return string.IsNullOrEmpty(subsetComment)
       ? $"@font-face {{\n" +
         $"font-family: '{fontName}';\n" +
         $"font-style: {fontStyle};\n" +
         $"font-weight: {fontWeight};\n" +
         $"font-stretch: 100%;\n" +
         $"src: url('{FontFileName(fontName, fontStyle, fontFileStyle)}.ttf')\n}}"
       : $"{subsetComment}" +
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
