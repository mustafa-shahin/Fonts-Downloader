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
                    if (subsets is not null && subsets.Any())
                    {
                        foreach (var subset in subsets)
                            CssList.Add(GenerateFontFaceCss(fontName, variant, woff, subset.ToLower()));
                    }
                    else
                        CssList.Add(GenerateFontFaceCss(fontName, variant, woff));

                }
            }       
            return CssList;
        }

        private string GenerateFontFaceCss(string fontName, string fontWeight, bool woff2, string subset = null)
        {
            if (!ValidateFontParameters(fontName, fontWeight)) return string.Empty;
            var fontStyle = fontWeight.Contains("italic") ? "italic" : "normal";
            var subsetComment = !string.IsNullOrEmpty(subset) ? $"/*{subset}*/\n" : "";
            var fontFileName = FontFileStyles.FontFileName(fontName, woff2, fontWeight);
            var formatAttribute = woff2 ? "format('woff2')" : "";
            var cssBuilder = new StringBuilder();
            cssBuilder.AppendLine($"{subsetComment}@font-face {{")
                      .AppendLine($"font-family: '{fontName}';")
                      .AppendLine($"font-style: {fontStyle};")
                      .AppendLine($"font-weight: {fontWeight.Replace("italic","")};")
                      .AppendLine("font-display: swap;")
                      .AppendLine($"font-stretch: 100%;")
                      .AppendLine($"src: url('{fontFileName}') {formatAttribute};")
                      .AppendLine("}");

            return cssBuilder.ToString();
        }
        private static bool ValidateFontParameters(string fontName, string fontWeight)
        {
            if (string.IsNullOrEmpty(fontName) || string.IsNullOrEmpty(fontWeight))
            {
                string missingParameters = string.Join(", ",
                    (string.IsNullOrEmpty(fontName)) ? "Font's name" : "",
                    string.IsNullOrEmpty(fontWeight) ? "Font's weight" : "");
                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
            return true;
        }
    }
}
