using System;
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
        private readonly HttpClient HttpClient;

        public FontFilesDownloader()
        {
            HttpClient = new HttpClient();
        }

        public async Task Download(Item item, string folderName, bool woff2)
        {
            ValidateParameters(item, folderName);

            var FontFileStyles = new FontFileStyles();

            foreach (var variant in item.Variants.Where(v => !string.IsNullOrEmpty(v)))
            {
                var FontStyle = variant.Contains("italic") ? "italic" : "normal";
                var FontFileStyle = FontFileStyles.GetFontFileStyles(variant) ?? variant;
                var PropertyValue = item.Files.GetType().GetProperty($"_{FontFileStyles.MapVariant(variant)}")?.GetValue(item.Files) as string;

                if (!string.IsNullOrEmpty(PropertyValue))
                {
                    await DownloadFontFile(item.Family, folderName, PropertyValue, woff2, FontFileStyle, FontStyle);
                }
            }
        }

        private static void ValidateParameters(Item item, string folderName)
        {
            if (item == null || string.IsNullOrEmpty(folderName))
            {
                string MissingParameters = string.Join(", ",
                    (item == null) ? "Item" : "",
                    string.IsNullOrEmpty(folderName) ? "FolderName" : "");

                throw new ArgumentException($"One or more required parameters are missing or invalid: {MissingParameters}");
            }
        }

        private async Task DownloadFontFile(string selectedFont, string folderName, string link, bool woff2, string fontFileStyle, string fontStyle)
        {
            var Format = woff2 ? "woff2" : "ttf";
            string FileName = Path.Combine(folderName, selectedFont.Replace(" ", ""), $"{FontFileStyles.FontFileName(selectedFont, fontStyle, fontFileStyle)}.{Format}");
            Uri Url = new(link);

            if (!File.Exists(FileName))
            {
                try
                {
                    var Response = await HttpClient.GetAsync(Url);
                    Response.EnsureSuccessStatusCode();

                    using var Stream = await Response.Content.ReadAsStreamAsync();
                    using var FileStream = File.Create(FileName);
                    await Stream.CopyToAsync(FileStream);
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
