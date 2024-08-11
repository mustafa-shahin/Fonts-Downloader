using System;
using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FontSelector
    {
        private string PreviousFont;

        public Item FontSelection(string selectedFontFamily, IEnumerable<Item> items,
            Action<string, IEnumerable<string>, IEnumerable<string>> updateUIComponents)
        {
            if (string.IsNullOrEmpty(selectedFontFamily) || selectedFontFamily == PreviousFont)
                return null;

            var selectedFontItem = items.FirstOrDefault(m => m.Family == selectedFontFamily);
            if (selectedFontItem != null && selectedFontItem.Variants.Count != 0)
            {
                var subsets = selectedFontItem.Subsets.Select(m => char.ToUpper(m[0]) + m[1..]);
                selectedFontItem.Variants = selectedFontItem.Variants
                    .Select(variant =>
                    {
                        string mappedVariant = (variant == "regular" || variant == "italic") ? Helper.MapVariant(variant) : variant;
                        return mappedVariant.EndsWith("italic") && !mappedVariant.Contains(' ') ? mappedVariant.Replace("italic", " italic") : mappedVariant;
                    })
                    .OrderBy(variant => variant.EndsWith(" italic"))
                    .ThenBy(variant => variant)
                    .ToList();

                var html = new HtmlFile();
                html.CreateHtml(selectedFontItem);
                updateUIComponents(selectedFontFamily, subsets, selectedFontItem.Variants);
            }

            PreviousFont = selectedFontFamily;
            return selectedFontItem;
        }
    }

}
