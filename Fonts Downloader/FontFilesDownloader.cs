using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FontFilesDownloader
    {
        public async Task Download(Item Item, string FolderName, bool Woff2)
        {
            var FontFileStyles = new FontFileStyles();
            ValidateParameters(Item, FolderName);
            foreach (var item in Item.Variants.Where(item => !string.IsNullOrEmpty(item)))
            {               
                var FontStyle = item.Contains("italic") ? "italic" : "normal";
                var FontFileStyle = FontFileStyles.GetFontFileStyles(item) ?? item;
                var PropertyValue = Item.Files.GetType().GetProperty($"_{SizeStyles.MapVariant(item)}")?.GetValue(Item.Files) as string;
                //var FontFileStyle = FontFileStyles.GetValueOrDefault(item.Replace("italic", "")) ?? item;
                //var PropertyValue = Items
                //    .Where(x => x.Family == SelectedFont)
                //    .Select(x => x.Files.GetType().GetProperty($"_{item}")?.GetValue(x.Files) as string)
                //    .FirstOrDefault();

                if (!string.IsNullOrEmpty(PropertyValue))
                {
                    await DownloadFontFile(Item.Family, FolderName, PropertyValue, Woff2, FontFileStyle, FontStyle);
                }
            }
        }

        private static void ValidateParameters(Item Items, string FolderName)
        {
            if (Items == null || string.IsNullOrEmpty(FolderName))
            {
                string missingParameters = string.Join(", ",
                    (Items == null) ? "Item" : "",
                    string.IsNullOrEmpty(FolderName) ? "FolderName" : "");

                throw new ArgumentException($"One or more required parameters are missing or invalid: {missingParameters}");
            }
        }

        private async Task DownloadFontFile(string SelectedFont, string FolderName, string Link, bool Woff2, string FontFileStyle, string FontStyle)
        {
            var format = Woff2 ? "Woff2" : "ttf";
            string FileName = Path.Combine(FolderName, SelectedFont.Replace(" ", ""), $"{SelectedFont.Replace(" ", "")}-{char.ToUpper(FontStyle[0]) + FontStyle[1..]}-{FontFileStyle}.{format}");
            Uri url = new(Link);
            if (!File.Exists(FileName))
            {
                try
                {
                    var httpClient = new HttpClient();
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
