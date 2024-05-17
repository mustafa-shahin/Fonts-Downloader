using System;
using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    public class FontSelector
    {
        private string PreviousFont;
        public Item FontSelection(string selectedFontFamily, IEnumerable<Item> items,
            Action<string, IEnumerable<string>, IEnumerable<string>> updateUIComponents)
        {
            var selectedFontItem = new Item();
            if (!string.IsNullOrEmpty(selectedFontFamily) && selectedFontFamily != PreviousFont)
            {
                selectedFontItem = items.FirstOrDefault(m => m.Family == selectedFontFamily);
                if (selectedFontItem != null && selectedFontItem.Variants.Any())
                {
                    var subsets = selectedFontItem.Subsets.Select(m => char.ToUpper(m[0]) + m[1..]);
                    selectedFontItem.Variants = [.. selectedFontItem.Variants.Select(variant =>
                    {
                        string mappedVariant = (variant == "regular" || variant == "italic") ? Helper.MapVariant(variant) : variant;
                        return mappedVariant.EndsWith("italic") && !mappedVariant.Contains(' ') ? mappedVariant.Replace("italic", " italic") : mappedVariant;
                    })
                    .OrderBy(variant => variant.EndsWith(" italic"))
                    .ThenBy(variant => variant)];

                    HtmlFile.CreateHtml(selectedFontItem);

                    updateUIComponents(selectedFontFamily, subsets, selectedFontItem.Variants);
                }
                PreviousFont = selectedFontFamily;
            }
            return selectedFontItem;
        }
    }
}
