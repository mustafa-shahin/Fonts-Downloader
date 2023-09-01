using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        private string previousFont = string.Empty;

        public void LoadSizeStyles(ComboBox FontBox, Label SelectedFont, CheckedListBox SizeAndStyle, CheckedListBox SubsetsLists, List<Item> Items)
        {
            string selectedFont = FontBox.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedFont) && selectedFont != previousFont)
            {
                SelectedFont.Text = selectedFont;
                SizeAndStyle.Items.Clear();
                foreach (var item in Items.Where(item => item.family == selectedFont))
                {
                    foreach (var variant in item.variants.Select(MapVariant))
                    {
                        SizeAndStyle.Items.Add(variant);
                    }
                }

                var subsets = Items
                    .Where(item => item.family == selectedFont)
                    .SelectMany(item => item.subsets)
                    .Select(item => char.ToUpper(item[0]) + item.Substring(1))
                    .ToList();

                SubsetsLists.Items.Clear();
                SubsetsLists.Items.AddRange(subsets.ToArray());

                previousFont = selectedFont;
            }
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
