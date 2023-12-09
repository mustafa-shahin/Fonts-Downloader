using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        public List<string> LoadSizeStyles(Item Font)
        {
            var Variants = new List<string>();
            var SelectedFontItems = Font.Family;
            Variants.AddRange(Font.Variants.Select(MapVariant)
                                           .OrderBy(variant => variant.EndsWith("italic"))
                                           .ThenBy(variant => variant)
                                           .ToList());
            return Variants;
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
    }
}
