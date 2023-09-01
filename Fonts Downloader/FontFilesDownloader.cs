using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Fonts_Downloader
{
    internal class FontFilesDownloader
    {
        public async Task FileLinks(CheckedListBox SizeAndStyle, Label SelectedFont, string FolderName, FontsCombox ApiResult)
        {
            var StylesNormal = ApiResult.LinksByVariantNormal;
            var StylesItalic = ApiResult.LinksByVariantItalic;
            var variants = SizeAndStyle.CheckedItems;
            var FontFileStyles = new Dictionary<string, string>
            {
                { "100", "Thin" },
                { "200", "ExtraLight" },
                { "300", "Light" },
                { "400", "Regular" },
                { "500", "Medium" },
                { "600", "SemiBold" },
                { "700", "Bold" },
                { "800", "ExtraBold" },
                { "900", "Black" },
            };
            foreach (var variant in variants)
            {
                string fontStyle = variant.ToString().Contains("italic") ? "italic" : "normal";
                bool isItalic = fontStyle == "italic";
                bool isValidVariant = variant.ToString().Contains(StylesNormal.Keys.FirstOrDefault(m => m == variant.ToString().Replace("italic", ""))) && (isItalic ? variant.ToString().Contains("italic") : !variant.ToString().Contains("italic"));

                if (isValidVariant)
                {
                    var selectedStyles = isItalic ? StylesItalic : StylesNormal;

                    if (selectedStyles.ContainsKey(variant.ToString()))
                    {
                        await FileDownloadAsync(SelectedFont.Text, FolderName, fontStyle, FontFileStyles[variant.ToString().Replace("italic", "")], selectedStyles[variant.ToString()]);
                    }
                }
            }
        }
        private async Task FileDownloadAsync(string selectedFont, string folderName, string fontStyle, string fontFileStyle, List<string> links)
        {
            using (var wc = new WebClient())
            {
                foreach (var link in links.Where(link => !string.IsNullOrEmpty(link) && link.Contains(selectedFont.Replace(" ", "").ToLower())))
                {
                    string[] fontFileLinks = link.ToLower().Split('/');
                    if (fontFileLinks.Contains(selectedFont.Replace(" ", "").ToLower()))
                    {
                        var fileName = $"{folderName}\\{selectedFont.Replace(" ", "")}\\{selectedFont.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontFileStyle}.ttf";
                        Uri url = new Uri(link);

                        if (!File.Exists(fileName))
                        {
                            await wc.DownloadFileTaskAsync(url, fileName);
                        }
                    }
                }
            }
        }

    }
}
