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

            if (CssList is not null && CssList.Any())
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
            if(variants is not null &&  variants.Any())
            {
                foreach (var variant in variants)
                {
                    var FontFileStyle = FontFileStyles.GetFontFileStyles(variant);
                    var fontStyle = variant.Contains("italic") ? "italic" : "normal";
                    var fontWeight = variant.Replace("italic", "").Trim();
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

        private string GenerateFontFaceCss(string fontName, string fontStyle, string fontWeight, bool woff, string fontFileStyle, string subset = null)
        {
            if (!ValidateFontParameters(fontName, fontStyle, fontWeight)) return string.Empty;

            var subsetComment = !string.IsNullOrEmpty(subset) ? $"/*{subset}*/\n" : "";
            var fontFileName = FontFileStyles.FontFileName(fontName, fontStyle, fontFileStyle);
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
        private static bool ValidateFontParameters(string fontName, string fontStyle, string fontWeight)
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
    }
}
