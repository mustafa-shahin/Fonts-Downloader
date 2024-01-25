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
        public void CreateCSS(Item selectedFont, string folderName, bool woff, bool minify = false, IEnumerable<string> subsets = null)
        {
            var CssList = GenerateCssList(selectedFont, woff, subsets);

            if (CssList is not null && CssList.Any())
            {
                string fontFolder = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""));
                if (!Directory.Exists(fontFolder))
                    Directory.CreateDirectory(fontFolder);

                string cssFilePath = Path.Combine(fontFolder, $"{selectedFont.Family.Replace(" ", "")}{(minify ? ".min" : "")}.css");
                string cssContent = string.Join("\n", CssList);

                if (minify)
                    cssContent = Uglify.Css(cssContent).ToString();

                File.WriteAllText(cssFilePath, cssContent);
            }
        }
        private List<string> GenerateCssList(Item selectedFont, bool woff, IEnumerable<string> subsets = null)
        {
            var CssList = new List<string>();
            foreach (var variant in selectedFont.Variants.Select(variant => variant.Replace(" ", "")))
            {
                var FontFileStyle = FontFileStyles.GetFontFileStyles(variant);
                if (subsets is not null && subsets.Any())
                {
                    foreach (var subset in subsets)
                        CssList.Add(GenerateFontFaceCss(selectedFont.Family, variant, woff, subset.ToLower()));
                }
                else
                    CssList.Add(GenerateFontFaceCss(selectedFont.Family, variant, woff));
            }
            return CssList;
        }

        private string GenerateFontFaceCss(string fontName, string fontWeight, bool woff2, string subset = null)
        {
            var fontStyle = fontWeight.Contains("italic") ? "italic" : "normal";
            var subsetComment = !string.IsNullOrEmpty(subset) ? $"/*{subset}*/\n" : "";
            var fontFileName = FontFileStyles.FontFileName(fontName, woff2, fontWeight);
            var formatAttribute = woff2 ? "format('woff2')" : "";
            var cssBuilder = new StringBuilder();
            cssBuilder.AppendLine($"{subsetComment}@font-face {{")
                      .AppendLine($"font-family: '{fontName}';")
                      .AppendLine($"font-style: {fontStyle};")
                      .AppendLine($"font-weight: {FontFileStyles.MapVariant(fontWeight).Replace("italic", "")};")
                      .AppendLine("font-display: swap;")
                      .AppendLine($"font-stretch: 100%;")
                      .AppendLine($"src: url('{fontFileName}') {formatAttribute};")
                      .AppendLine("}");

            return cssBuilder.ToString();
        }
    }
}
