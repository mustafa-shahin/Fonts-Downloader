using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task FileLinks(List<Item> items, string selectedFont, string folderName, List<string> variants, bool woff2)
        {
            ValidateParameters(items, selectedFont, folderName, variants);

            var fontFileStyles = new Dictionary<string, string>
            {
                { "100", "Thin" }, { "200", "ExtraLight" },
                { "300", "Light" }, { "400", "Regular" },
                { "500", "Medium" }, { "600", "SemiBold" },
                { "700", "Bold" }, { "800", "ExtraBold" },
                { "900", "Black" },
            };

            foreach (var item in variants)
            {
                if (!string.IsNullOrEmpty(item) && fontFileStyles.TryGetValue(item.Replace("italic", ""), out var fontFileStyle))
                {
                    var fontStyle = item.Contains("italic") ? "italic" : "normal";
                    var propertyValue = items
                        .Where(x => x.Family == selectedFont)
                        .Select(x => x.Files.GetType().GetProperty($"_{item}")?.GetValue(x.Files) as string)
                        .FirstOrDefault();

                    if (!string.IsNullOrEmpty(propertyValue))
                    {
                        await DownloadFontFileAsync(selectedFont, folderName, propertyValue, woff2, fontFileStyle, fontStyle);
                    }
                }
            }
        }

        private void ValidateParameters(List<Item> items, string selectedFont, string folderName, List<string> variants)
        {
            if (items == null || !items.Any() || string.IsNullOrEmpty(selectedFont) || string.IsNullOrEmpty(folderName) || variants == null || !variants.Any())
            {
                string missingParameters = string.Join(", ",
                    (items == null || !items.Any()) ? "Items" : "",
                    string.IsNullOrEmpty(selectedFont) ? "SelectedFont" : "",
                    string.IsNullOrEmpty(folderName) ? "FolderName" : "",
                    (variants == null || !variants.Any()) ? "Variants" : "");

                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
        }

        public async Task DownloadFontFileAsync(string selectedFont, string folderName, string link, bool woff2, string fontFileStyle = null, string fontStyle = null)
        {
            var format = woff2 ? "woff2" : "ttf";
            if (string.IsNullOrEmpty(link))
            {
                throw new ArgumentException($"A parameter is missing or invalid: {link}");
            }

            string[] fontFileLinks = link.ToLower().Split('/');
            if (fontFileLinks.Contains(selectedFont.Replace(" ", "").ToLower()))
            {
                string fileName = Path.Combine(folderName, selectedFont.Replace(" ", ""), $"{selectedFont.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontFileStyle}.{format}");
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
