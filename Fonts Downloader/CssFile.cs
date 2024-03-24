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
        public void CreateCSS(Item selectedFont, string folderName, bool includeWoff2, bool minify = false, IEnumerable<string> subsets = null)
        {
            var cssEntries = GenerateCssEntries(selectedFont, includeWoff2, subsets);

            if (cssEntries is not null && cssEntries.Any())
            {
                string fontFolder = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""));
                if (!Directory.Exists(fontFolder))
                    Directory.CreateDirectory(fontFolder);

                string cssFileName = $"{selectedFont.Family.Replace(" ", "")}{(minify ? ".min" : "")}.css";
                string cssFilePath = Path.Combine(fontFolder, cssFileName);
                string cssContent = string.Join(Environment.NewLine, cssEntries);

                if (minify)
                {
                    var result = Uglify.Css(cssContent);
                    if (result.HasErrors)
                        throw new Exception("CSS Minification failed.");

                    cssContent = result.Code;
                }

                File.WriteAllText(cssFilePath, cssContent);
            }
        }
        private IEnumerable<string> GenerateCssEntries(Item selectedFont, bool includeWoff2, IEnumerable<string> subsets = null)
        {
            return selectedFont.Variants.SelectMany(variant =>
                (subsets?.Any() ?? false) ? subsets.Select(subset => GenerateFontFace(selectedFont.Family, variant, includeWoff2, subset)) :
                new[] { GenerateFontFace(selectedFont.Family, variant, includeWoff2) });
        }

        private string GenerateFontFace(string fontFamily, string fontWeight, bool woff2, string subset = null)
        {
            string fontStyle = fontWeight.Contains("italic") ? "italic" : "normal";
            string subsetComment = subset != null ? $"/*{subset}*/\n" : string.Empty;
            string fontFileName = Helper.FontFileName(fontFamily, woff2, fontWeight);
            string formatAttribute = woff2 ? " format('woff2')" : string.Empty;
            string fontVariant = Helper.MapVariant(fontWeight).TrimEnd("italic".ToCharArray());
            var cssBuilder = new StringBuilder()
                .AppendLine($"{subsetComment}@font-face {{")
                .AppendLine($"font-family: '{fontFamily}';")
                .AppendLine($"font-style: {fontStyle};")
                .AppendLine($"font-weight: {fontVariant};")
                .AppendLine("font-display: swap;")
                .AppendLine("font-stretch: normal;")
                .AppendLine($"src: url('{fontFileName}'){formatAttribute};")
                .AppendLine("}");

            return cssBuilder.ToString();
        }

    }
}
