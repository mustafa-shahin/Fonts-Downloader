using System.Collections.Generic;

namespace Fonts_Downloader
{
    public  class FontFileStyles
    {
        public static string GetFontFileStyles(string style)
        {
            var FontFileStyles = new Dictionary<string, string>
            {
                { "100", "Thin" }, { "200", "ExtraLight" },
                { "300", "Light" },  { "400", "Regular" },
                { "500", "Medium" }, { "600", "SemiBold" },
                { "700", "Bold" }, { "800", "ExtraBold" },
                { "900", "Black" },
            };
            var FontStyle = style.Contains("italic") ? style.Replace("italic","") : style;
            var FontFileStyle = FontFileStyles.GetValueOrDefault(FontStyle);
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
        public static string FontFileName(string fontName, string fontStyle, string fontWeight)
        {
            return $"{fontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle[1..]}-{fontWeight}";
        }
    }
}
