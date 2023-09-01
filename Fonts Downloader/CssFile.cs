using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        private readonly Dictionary<string, string> FontFileStyles = new Dictionary<string, string>
        {
            { "100", "Thin" },
            { "200", "ExtraLight" },
            { "300", "Light" },
            { "400", "Regular" },
            { "500", "Medium" },
            { "600", "SemiBold" },
            { "700", "Bold" },
            { "800", "ExtraBold" },
            { "900", "Black" },
        };

        private List<string> Styles { get; } = new List<string>();
        private List<string> FontWeight { get; } = new List<string>();
        public List<string> FontWeights => FontWeight;

        public void CreateCSS(CheckedListBox sizeAndStyle, CheckedListBox subsetsLists, string folderName, string fontName)
        {
            var cssList = new List<string>();

            foreach (var checkedItem in sizeAndStyle.CheckedItems.Cast<string>())
            {
                if (ParseCheckedItem(checkedItem, out var fontStyle, out var fontWeight))
                {
                    Styles.Add(fontStyle);
                    FontWeight.Add(fontWeight);
                    string fontFileStyle = FontFileStyles[fontWeight];
                    if (subsetsLists.CheckedIndices.Count > 0)
                    {
                        foreach (var subset in subsetsLists.CheckedItems.Cast<string>())
                        {
                            var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, subset.ToLower() , fontFileStyle);
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

            if (cssList.Any())
            {
                string fontFolder = Path.Combine(folderName, fontName.Replace(" ", ""));
                Directory.CreateDirectory(fontFolder);

                string cssFilePath = Path.Combine(fontFolder, $"{fontName.Replace(" ", "")}.css");

                File.WriteAllLines(cssFilePath, cssList);
            }
        }

        private bool ParseCheckedItem(string checkedItem, out string fontStyle, out string fontWeight)
        {
            fontStyle = checkedItem.Contains("italic") ? "italic" : "normal";
            fontWeight = checkedItem.Replace("italic", "").Trim();

            return !string.IsNullOrWhiteSpace(fontWeight) && FontFileStyles.TryGetValue(fontWeight, out _);
        }

        private string GenerateFontFaceCss(string fontName, string fontStyle, string fontWeight, string fontFileStyle, string subset = null)
        {
            var Subset = !string.IsNullOrWhiteSpace(subset) ? $"/*{subset}*/\n" : "";
            return Subset +
                   $"@font-face {{\n" +
                   $"font-family: '{fontName}';\n" +
                   $"font-style: {fontStyle};\n" +
                   $"font-weight: {fontWeight};\n" +
                   $"font-stretch: 100%;\n" +
                   $"src: url('{CssFileName(fontName, fontStyle, fontFileStyle)}.ttf')\n}}";
        }

        private string CssFileName(string fontName, string fontStyle, string fontWeight)
        {
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontWeight}";
        }
    }
}
