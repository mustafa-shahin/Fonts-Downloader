using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    public static class FontFileStyles
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
    }
}
