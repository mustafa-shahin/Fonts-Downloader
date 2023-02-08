using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class SizeStyles
    {
        private string old = string.Empty;
        //public string Old { set { old=value; } get { return old; } }
        private List<string> Subset = new List<string>();
        public List<string> SubsetList { get { return Subset; } }
        public void SizeStylesLoad(ComboBox FontBox, Label SelectedFont, CheckedListBox SizeAndStyle, List<Item> Items)
        {
            if (FontBox.SelectedIndex > -1)
            {
                SelectedFont.Text = FontBox.SelectedItem.ToString();
            }
            if (SelectedFont.Text != old)
            {
                SizeAndStyle.Items.Clear();
            }
            foreach (var item in Items)
            {
                if (FontBox.SelectedItem.ToString() == item.family)
                {
                    for (int i = 0; i < item.variants.Count; i++)
                    {
                        if (item.variants[i] == "regular")
                        {
                            item.variants[i] = "400";
                        }
                        if (item.variants[i] == "italic")
                        {
                            item.variants[i] = "400italic";
                        }
                        SizeAndStyle.Items.Add(item.variants[i]);
                    }
                    for (int i = 0; i < item.subsets.Count; i++)
                    {
                        Subset.Add(item.subsets[i]);
                    }
                }
            }
            old = SelectedFont.Text;            
        }
    }
}
