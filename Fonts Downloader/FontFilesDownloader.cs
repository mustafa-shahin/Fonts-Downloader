using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    internal class FontFilesDownloader
    {
        public async Task FileLinks(List<Item> Items, string SelectedFont, string FolderName, List<string> Variants)
        {
            var fontStyle = string.Empty;
            var propertyValue = string.Empty;
            var selectedItems = Items.Where(item => item.family == SelectedFont).ToList();
            var FontFileStyles = new Dictionary<string, string>
            {
                        { "100", "Thin" },{ "200", "ExtraLight" },
                        { "300", "Light" },{ "400", "Regular" },
                        { "500", "Medium" },{ "600", "SemiBold" },
                        { "700", "Bold" },{ "800", "ExtraBold" },
                        { "900", "Black" },
            };

            foreach (var item in Variants)
            {
                fontStyle = item.Contains("italic") ? "italic" : "normal";
                //var propertyName = $"_{item}";
                //var propertyName = selectedItems.Any(x => x.variants.Any(variant => variant == "regular" || variant == "italic"))
                //                    ? $"_{item}"
                //                    : selectedItems.Any(x => x.variants.Any(variant => variant == fontStyle))
                //                    ? $"_{fontStyle}"
                //                    : "";
                if (!string.IsNullOrEmpty(item))
                {
                    propertyValue = selectedItems.Select(x => x.files.GetType().GetProperty($"_{item}")?.GetValue(x.files) as string)
                                .FirstOrDefault();
                }
                if (!string.IsNullOrEmpty(propertyValue))
                    await FileDownloadAsync(SelectedFont, FolderName, fontStyle, FontFileStyles[item.Replace("italic", "")], propertyValue);
            }
        }

        private async Task FileDownloadAsync(string selectedFont, string folderName, string fontStyle, string fontFileStyle, string links)
        {
            using (var wc = new WebClient())
            {
                string[] fontFileLinks = links.ToLower().Split('/');
                if (fontFileLinks.Contains(selectedFont.Replace(" ", "").ToLower()))
                {
                    var fileName = $"{folderName}\\{selectedFont.Replace(" ", "")}\\{selectedFont.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontFileStyle}.ttf";
                    Uri url = new Uri(links);

                    if (!File.Exists(fileName))
                    {
                        await wc.DownloadFileTaskAsync(url, fileName);
                    }
                }
            }
        }
    }
}
