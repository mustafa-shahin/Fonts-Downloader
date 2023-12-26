using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
               
                    File.WriteAllText(cssFilePath, cssContent);
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
                    if (subsets is not null && subsets.Any())
                    {
                        foreach (var subset in subsets)                           
                            CssList.Add(GenerateFontFaceCss(fontName, fontStyle, fontWeight, woff, FontFileStyle, subset.ToLower()));
                        
                    }
                    else
                        CssList.Add(GenerateFontFaceCss(fontName, fontStyle, fontWeight, woff, FontFileStyle));
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

            var cssBuilder = new StringBuilder();
            cssBuilder.AppendLine($"{subsetComment}@font-face {{")
                      .AppendLine($"font-family: '{fontName}';")
                      .AppendLine($"font-style: {fontStyle};")
                      .AppendLine($"font-weight: {fontWeight};")
                      .AppendLine("font-display: swap;")
                      .AppendLine($"font-stretch: 100%;")
                      .AppendLine($"src: url('{fontFileName}.{format}'){formatAttribute};")
                      .AppendLine("}");

            return cssBuilder.ToString();
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
