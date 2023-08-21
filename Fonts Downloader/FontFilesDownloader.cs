using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class FontFilesDownloader
    {
        private readonly string[] variants = new string[] { "100", "100italic", "200", "200italic", "300", "300italic", "400", "400italic", "500", "500italic", "600", "600italic", "700", "700italic", "800", "800italic", "900", "900italic" };
        public void FileLinks(CheckedListBox SizeAndStyle, List<string> FontWeight, Label SelectedFont, string FolderName, FontsCombox ApiResult)
        {
            var StylesNormal = ApiResult.LinksByVariantNormal;
            var StylesItalic = ApiResult.LinksByVariantItalic;

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

            foreach (string checkedItem in SizeAndStyle.CheckedItems)
            {
                string fontStyle = checkedItem.Contains("italic") ? "italic" : "normal";

                foreach (var variant in variants)
                {
                    foreach (string fontWeight in FontWeight)
                    {
                        bool isItalic = fontStyle == "italic";
                        bool isValidVariant = variant.Contains(fontWeight) && (isItalic ? variant.Contains("italic") : !variant.Contains("italic"));

                        if (isValidVariant)
                        {
                            Dictionary<string, List<string>> selectedStyles = isItalic ? StylesItalic : StylesNormal;

                            if (selectedStyles.ContainsKey(variant))
                            {
                                FileDownload(SelectedFont.Text, FolderName, fontStyle, FontFileStyles[fontWeight], selectedStyles[variant]);
                            }
                        }
                    }
                }
            }

        }
        private void FileDownload(string selectedFont, string folderName, string fontStyle, string fontFileStyle, List<string> links)
        {
            foreach (var link in links)
            {
                if (!string.IsNullOrEmpty(link) && link.Replace("/", " ").Contains(selectedFont.ToLower().Replace(" ", "")))
                {
                    string[] fontFileLinks = link.ToLower().Split('/');
                    foreach (string fontName in fontFileLinks)
                    {
                        if (fontName == selectedFont.ToLower().Replace(" ", ""))
                        {
                            var fileName = $"{folderName}\\{selectedFont.Replace(" ", "")}\\{selectedFont.Replace(" ", "")}-{fontStyle.Substring(0, 1).ToUpper() + fontStyle.Substring(1)}-{fontFileStyle}.ttf";
                            WebClient wc = new WebClient();
                            Uri url = new Uri(link);
                            if (!File.Exists(fileName))
                            {
                                wc.DownloadFileTaskAsync(url, fileName);
                            }
                        }
                    }
                }
            }
        }
    }
}
