using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class FontFilesDownloader
    {
        private readonly HttpClient httpClient;

        public FontFilesDownloader()
        {
            httpClient = new HttpClient();
        }

        public async Task FileLinks(List<Item> Items, string SelectedFont, string FolderName, List<string> Variants)
        {
            if (Items == null || !Items.Any() || string.IsNullOrEmpty(SelectedFont) ||
                   string.IsNullOrEmpty(FolderName) || Variants == null || !Variants.Any())
            {
                string missingParameters = string.Join(", ",
                    (Items == null || !Items.Any()) ? "Items" : "",
                    string.IsNullOrEmpty(SelectedFont) ? "SelectedFont" : "",
                    string.IsNullOrEmpty(FolderName) ? "FolderName" : "",
                    (Variants == null || !Variants.Any()) ? "Variants" : "");

                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
            var fontStyle = string.Empty;
            var propertyValue = string.Empty;
            var selectedItems = Items.Where(item => item.Family == SelectedFont).ToList();
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
                //var propertyName = $"_{item}";
                if (!string.IsNullOrEmpty(item))
                {
                    propertyValue = selectedItems.Select(x => x.Files.GetType().GetProperty($"_{item}")?.GetValue(x.Files) as string)
                                .FirstOrDefault();
                }
                if (!string.IsNullOrEmpty(propertyValue))
                    await DownloadFontFileAsync(SelectedFont, FolderName, propertyValue, FontFileStyles[item.Replace("italic", "")], fontStyle);
            }
        }

        private async Task DownloadFontFileAsync(string selectedFont, string folderName,  string link, string fontFileStyle=null, string fontStyle=null)
        {
            if (string.IsNullOrEmpty(link))
            {
                throw new ArgumentException($" A Parameters is missing or invalid: {link}");
            }
            string[] fontFileLinks = link.ToLower().Split('/');
            if (fontFileLinks.Contains(selectedFont.Replace(" ", "").ToLower()))
            {
                string fileName = $"{folderName}\\{selectedFont.Replace(" ", "")}\\{selectedFont.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontFileStyle}.ttf";
                Uri url = new Uri(link);
                if (!File.Exists(fileName))
                {
                    try
                    {
                        var response = await httpClient.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        using (var stream = await response.Content.ReadAsStreamAsync())
                        using (var fileStream = File.Create(fileName))
                        {
                            await stream.CopyToAsync(fileStream);
                        }
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error downloading font file: {ex.Message}");
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error saving font file: {ex.Message}");
                    }
                }
            }
        }
    }
}
