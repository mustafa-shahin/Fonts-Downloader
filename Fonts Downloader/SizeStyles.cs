using System;
using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        public  List<string> LoadSizeStyles(List<Item> Fonts, string SelectedFont)
        {
             var Variants = new List<string>();
             var SelectedFontItems = Fonts.Where(item => item.Family == SelectedFont);

            foreach (var item in SelectedFontItems)
            {
                Variants.AddRange(item.Variants.Select(MapVariant));
            }
            Variants = Variants.OrderBy(variant => variant.EndsWith("italic", StringComparison.OrdinalIgnoreCase))
                                 .ThenBy(variant => variant)
                                 .ToList();
            return Variants;
        }

        private string MapVariant(string variant)
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
