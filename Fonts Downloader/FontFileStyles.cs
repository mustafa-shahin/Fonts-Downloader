using NUglify.JavaScript.Syntax;
using System.Collections.Generic;

namespace Fonts_Downloader
{
    public  class FontFileStyles
    {
        public static string GetFontFileStyles(string weight)
        {
            var FontFileStyles = new Dictionary<string, string>
            {
                { "100", "Thin" }, { "200", "ExtraLight" },
                { "300", "Light" },  { "400", "Regular" },
                { "500", "Medium" }, { "600", "SemiBold" },
                { "700", "Bold" }, { "800", "ExtraBold" },
                { "900", "Black" },
            };
            var FontFileStyle = FontFileStyles.GetValueOrDefault(weight.Replace("italic", ""));
            return FontFileStyle;
        }
        public static string MapVariant(string variant)
        {
            return variant switch
            {
                "regular" => "400",
                "italic" => "400italic",
                _ => variant,
            };
        }
        public static string FontFileName(string fontName, bool woff2, string weight)
        {
            var fontFileStyle = GetFontFileStyles(MapVariant(weight).Replace("italic",""));
            var fontStyle = weight.Contains("italic") ? "italic" : "normal";
            var format = woff2 ? "woff2" : "ttf";
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontFileStyle}.{format}";
        }
    }
}
