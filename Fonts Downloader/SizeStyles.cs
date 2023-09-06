using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        private readonly List<string> variants = new List<string>();
        public List<string> Variants => variants;
        public List<string> LoadSizeStyles(List<Item> Font, string seletedFont)
        {
            foreach (var item in Font.Where(item => item.family == seletedFont))
            {
                foreach (var variant in item.variants.Select(MapVariant))
                {
                    variants.Add(variant);
                }
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
