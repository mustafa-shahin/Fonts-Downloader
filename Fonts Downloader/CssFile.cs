using NUglify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class CssFile
    {
        public void CreateCSS(Item selectedFont, string folderName, bool includeWoff2, bool minify = false, IEnumerable<string> subsets = null)
        {
            try
            {
                var cssEntries = GenerateCssEntries(selectedFont, includeWoff2, subsets);
                if (cssEntries.Any())
                {
                    string fontFolder = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""));
                    Directory.CreateDirectory(fontFolder);

                    string cssFileName = $"{selectedFont.Family.Replace(" ", "")}{(minify ? ".min" : "")}.css";
                    string cssFilePath = Path.Combine(fontFolder, cssFileName);
                    string cssContent = string.Join(Environment.NewLine, cssEntries);

                    if (minify)
                    {
                        var result = Uglify.Css(cssContent);
                        if (result.HasErrors)
                        {
                            throw new Exception("CSS Minification failed: " + result.Errors.First().Message);
                        }
                        cssContent = result.Code;
                    }

                    File.WriteAllText(cssFilePath, cssContent);
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to create CSS file", ex);
            }          
        }

        private IEnumerable<string> GenerateCssEntries(Item selectedFont, bool includeWoff2, IEnumerable<string> subsets = null)
        {
            return selectedFont.Variants.SelectMany(variant =>
                                            subsets != null && subsets.Any()
                                            ? subsets.Select(subset => GenerateFontFace(selectedFont.Family, variant, includeWoff2, subset))
                                            : [GenerateFontFace(selectedFont.Family, variant, includeWoff2)]);
        }

        private string GenerateFontFace(string fontFamily, string fontWeight, bool woff2, string subset = null)
        {
            string fontStyle = fontWeight.Contains("italic") ? "italic" : "normal";
            string subsetComment = subset != null ? $"/*{subset}*/\n" : string.Empty;
            string fontFileName = Helper.FontFileName(fontFamily, woff2, fontWeight);
            string formatAttribute = woff2 ? " format('woff2')" : string.Empty;
            string fontVariant = Helper.MapVariant(fontWeight).TrimEnd("italic".ToCharArray());
            CssStyle styles = new();
            styles.Properties[$"{subsetComment}@font-face"] = new Dictionary<string, string>
            {
                {"font-family",$"'{fontFamily}'"},
                {"font-style",fontStyle},
                {"font-weight", fontVariant},
                {"font-display", "swap"},
                { "font-stretch", "normal"},
                {"src", $"url('{fontFileName}'){formatAttribute}"}
            };
            return styles.Render();
        }
    }
}
