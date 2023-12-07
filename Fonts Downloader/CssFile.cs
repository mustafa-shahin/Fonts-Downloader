﻿using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        public void CreateCSS(IEnumerable<string> variants, string folderName, string fontName, bool woff, bool minify = false, IEnumerable<string> subsets = null)
        {
            var CssList = GenerateCssList(variants, fontName, woff, subsets);

            if (CssList !=null && CssList.Any())
            {
                string fontFolder = Path.Combine(folderName, fontName.Replace(" ", ""));
                if (!Directory.Exists(fontFolder))

                    Directory.CreateDirectory(fontFolder);

                string cssFilePath = Path.Combine(fontFolder, $"{fontName.Replace(" ", "")}{(minify ? ".min" : "")}.css");
                string cssContent = string.Join("\n", CssList);

                if (minify)
                    cssContent = Uglify.Css(cssContent).ToString();

                if (!File.Exists(cssFilePath) || (File.Exists(cssFilePath) && string.IsNullOrEmpty(File.ReadAllText(cssFilePath))))
                    File.WriteAllText(cssFilePath, cssContent);

                else
                {
                    string fileContents = File.ReadAllText(cssFilePath);  
                    if (woff && fileContents.Contains(".ttf") || !woff && fileContents.Contains(".woff2"))
                        File.WriteAllText(cssFilePath, cssContent);

                    else
                    {
                        if (!fileContents.Contains(cssContent))
                        {
                            string newString = cssContent.Replace(fileContents, "");
                            int index = fileContents.IndexOf(cssContent);
                            if (index == -1)
                                File.AppendAllText(cssFilePath, newString);
                        }
                    }
                }
            }
        }
        private List<string> GenerateCssList(IEnumerable<string> variants, string fontName, bool woff, IEnumerable<string> subsets = null)
        {
            var CssList = new List<string>();
            var FontFileStyles = new FontFileStyles();
            foreach (var variant in variants)
            {               
                var FontFileStyle = FontFileStyles.GetFontFileStyles(variant);
                if (ParseCheckedItem(variant, out var fontStyle, out var fontWeight))
                {
                    if (subsets != null && subsets.Any())
                    {
                        foreach (var subset in subsets)
                        {
                            var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, woff, FontFileStyle, subset.ToLower());
                            CssList.Add(css);
                        }
                    }
                    else
                    {
                        var css = GenerateFontFaceCss(fontName, fontStyle, fontWeight, woff, FontFileStyle);
                        CssList.Add(css);
                    }

                }
            }
            return CssList;
        }

        private  bool ParseCheckedItem(string checkedItem, out string fontStyle, out string fontWeight)
        {
            fontStyle = checkedItem.Contains("italic") ? "italic" : "normal";
            fontWeight = checkedItem.Replace("italic", "").Trim();

            return !string.IsNullOrWhiteSpace(fontWeight);
        }

        private string GenerateFontFaceCss(string fontName, string fontStyle, string fontWeight, bool woff, string fontFileStyle, string subset = null)
        {
            if (!ValidateFontParameters(fontName, fontStyle, fontWeight)) return string.Empty;

            var subsetComment = !string.IsNullOrEmpty(subset) ? $"/*{subset}*/\n" : "";

            var fontFileName = FontFileName(fontName, fontStyle, fontFileStyle);

            var format = woff ? "woff2" : "ttf";
            var formatAttribute = format == "ttf" ? "" : $" format('{format}')";

            var css = $"{subsetComment}@font-face {{\n" +
                       $"  font-family: '{fontName}';\n" +
                       $"  font-style: {fontStyle};\n" +
                       $"  font-weight: {fontWeight};\n" +
                       "  font-display: swap;\n" +
                       $"  font-stretch: 100%;\n" +
                       $"  src: url('{fontFileName}.{format}'){formatAttribute};\n";

            if (woff)
            {
                css += "  unicode-range: U+0460-052F, U+1C80-1C88, U+20B4, U+2DE0-2DFF, U+A640-A69F, U+FE2E-FE2F;\n";
            }

            css += "}";

            return css;
        }
        private bool ValidateFontParameters(string fontName, string fontStyle, string fontWeight)
        {
            if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(fontStyle) || string.IsNullOrEmpty(fontWeight))
            {
                string missingParameters = string.Join(", ",
                    (string.IsNullOrEmpty(fontName)) ? "Font's name" : "",
                    string.IsNullOrEmpty(fontStyle) ? "Font's style" : "",
                    string.IsNullOrEmpty(fontWeight) ? "Font's weight" : "");
                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
            return true;
        }
        private string FontFileName(string fontName, string fontStyle, string fontWeight)
        {
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontWeight}";
        }
    }
}
