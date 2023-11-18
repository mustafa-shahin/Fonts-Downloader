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

        public async Task Download(List<Item> Items, string SelectedFont, string FolderName, List<string> Variants, bool Woff2)
        {
            ValidateParameters(Items, SelectedFont, FolderName, Variants);
            foreach (var item in Variants)
            {
                if (!string.IsNullOrEmpty(item))
                {                   
                    var FontStyle = item.Contains("italic") ? "italic" : "normal";
                    var FontFileStyle = FontFileStyles.GetFontFileStyles(item) ?? item;
                    //var FontFileStyle = FontFileStyles.GetValueOrDefault(item.Replace("italic", "")) ?? item;
                    var PropertyValue = Items
                        .Where(x => x.Family == SelectedFont)
                        .Select(x => x.Files.GetType().GetProperty($"_{item}")?.GetValue(x.Files) as string)
                        .FirstOrDefault();

                    if (!string.IsNullOrEmpty(PropertyValue))
                    {
                        await DownloadFontFileAsync(SelectedFont, FolderName, PropertyValue, Woff2, FontFileStyle, FontStyle);
                    }
                }
            }
        }

        private static void ValidateParameters(List<Item> Items, string selectedFont, string FolderName, List<string> Variants)
        {
            if (Items == null || !Items.Any() || string.IsNullOrEmpty(selectedFont) || string.IsNullOrEmpty(FolderName) || Variants == null || !Variants.Any())
            {
                string missingParameters = string.Join(", ",
                    (Items == null || !Items.Any()) ? "Items" : "",
                    string.IsNullOrEmpty(selectedFont) ? "SelectedFont" : "",
                    string.IsNullOrEmpty(FolderName) ? "FolderName" : "",
                    (Variants == null || !Variants.Any()) ? "Variants" : "");

                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
        }

        public async Task DownloadFontFileAsync(string SelectedFont, string FolderName, string Link, bool Woff2, string FontFileStyle , string FontStyle)
        {
            var format = Woff2 ? "Woff2" : "ttf";
            string[] fontFileLinks = Link.ToLower().Split('/');
            if (fontFileLinks.Contains(SelectedFont.Replace(" ", "").ToLower()))
            {
                string FileName = Path.Combine(FolderName, SelectedFont.Replace(" ", ""), $"{SelectedFont.Replace(" ", "")}-{char.ToUpper(FontStyle[0]) + FontStyle[1..]}-{FontFileStyle}.{format}");
                Uri url = new(Link);
                if (!File.Exists(FileName))
                {
                    try
                    {
                        var response = await httpClient.GetAsync(url);
                        response.EnsureSuccessStatusCode();

                        using var stream = await response.Content.ReadAsStreamAsync();
                        using var fileStream = File.Create(FileName);
                        await stream.CopyToAsync(fileStream);
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
