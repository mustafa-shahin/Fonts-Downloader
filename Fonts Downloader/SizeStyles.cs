using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        public  List<string> LoadSizeStyles(List<Item> fonts, string selectedFont)
        {
             var variants = new List<string>();
             var selectedFontItems = fonts.Where(item => item.Family == selectedFont);

            foreach (var item in selectedFontItems)
            {
                variants.AddRange(item.Variants.Select(MapVariant));
            }

            return variants;
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
