using System;
using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    public class FontSelector
    {
        private string PreviousFont;
        public void ProcessFontSelection(out Item selectedFontItem, string selectedFontFamily, IEnumerable<Item> items,
            Action<string, IEnumerable<string>, IEnumerable<string>> updateUIComponents)
        {
            selectedFontItem = null;
            if (!string.IsNullOrEmpty(selectedFontFamily) && selectedFontFamily != PreviousFont)
            {
                 selectedFontItem = items.FirstOrDefault(m => m.Family == selectedFontFamily);
                if (selectedFontItem != null)
                {
                    var subsets = selectedFontItem.Subsets.Select(m => char.ToUpper(m[0]) + m[1..]);
                    var variants = selectedFontItem.Variants.Select(variant =>
                    {
                        string mappedVariant = (variant == "regular" || variant == "italic") ? Helper.MapVariant(variant) : variant;
                        return mappedVariant.EndsWith("italic") && !mappedVariant.Contains(' ') ? mappedVariant.Replace("italic", " italic") : mappedVariant;
                    })
                    .OrderBy(variant => variant.EndsWith(" italic"))
                    .ThenBy(variant => variant)
                    .ToList();

                    HtmlFile.CreateHtml(selectedFontItem);

                    updateUIComponents(selectedFontFamily, subsets, variants);
                }
                PreviousFont = selectedFontFamily;
            }
        }
    }
}
