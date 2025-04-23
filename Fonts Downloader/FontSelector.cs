using System;
using System.Collections.Generic;
using System.Linq;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FontSelector
    {
        private string _previousFont;

        public Item FontSelection(string selectedFontFamily, IEnumerable<Item> items,
            Action<string, IEnumerable<string>, IEnumerable<string>> updateUIComponents)
        {
            if (string.IsNullOrEmpty(selectedFontFamily) || selectedFontFamily == _previousFont || items == null)
                return null;

            var selectedFontItem = items.FirstOrDefault(m => m.Family == selectedFontFamily);
            if (selectedFontItem != null && selectedFontItem.Variants?.Count > 0)
            {
                // Process the variants into a more user-friendly format
                var subsets = selectedFontItem.Subsets?
                    .Select(m => string.IsNullOrEmpty(m) ? m : char.ToUpper(m[0]) + m[1..])
                    .ToList() ?? [];

                selectedFontItem.Variants = [.. selectedFontItem.Variants
                    .Select(variant =>
                    {
                        string mappedVariant = (variant == "regular" || variant == "italic") ? Helper.MapVariant(variant) : variant;
                        return mappedVariant.EndsWith("italic") && !mappedVariant.Contains(' ') ? mappedVariant.Replace("italic", " italic") : mappedVariant;
                    })
                    .OrderBy(variant => variant.EndsWith(" italic")) // Regular weights first, then italics
                    .ThenBy(variant => variant)];

                // Generate HTML preview
                var html = new HtmlBuilder();
                html.CreateHtml(selectedFontItem);

                // Update UI components
                updateUIComponents(selectedFontFamily, subsets, selectedFontItem.Variants);
            }

            _previousFont = selectedFontFamily;
            return selectedFontItem;
        }
    }
}