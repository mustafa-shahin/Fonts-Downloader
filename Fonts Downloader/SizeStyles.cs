using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        private readonly List<string> variants = new List<string>();

        public List<string> Variants => variants;

        public List<string> LoadSizeStyles(List<Item> fonts, string selectedFont)
        {
            var selectedFontItems = fonts.Where(item => item.Family == selectedFont);

            foreach (var item in selectedFontItems)
            {
                variants.AddRange(item.Variants.Select(MapVariant));
            }

            return variants;
        }

        private string MapVariant(string variant)
        {
            switch (variant)
            {
                case "regular":
                    return "400";
                case "italic":
                    return "400italic";
                default:
                    return variant;
            }
        }
    }
}
