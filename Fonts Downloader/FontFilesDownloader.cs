using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FontFilesDownloader : IDisposable
    {
        private readonly HttpClient httpClient;

        public FontFilesDownloader()
        {
            this.httpClient = new HttpClient();
        }

        public async Task DownloadAsync(Item selectedFont, string folderName, bool woff2)
        {
            foreach (var variant in selectedFont.Variants.Select(v => v.Replace(" ", "")))
            {
                var fontFileStyle = FontFileStyles.GetFontFileStyles(variant) ?? variant;
                var propertyValue = selectedFont.Files.GetType().GetProperty($"_{FontFileStyles.MapVariant(variant)}")?.GetValue(selectedFont.Files) as string;

                if (!string.IsNullOrEmpty(propertyValue))
                {
                    string FileName = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""), $"{FontFileStyles.FontFileName(selectedFont.Family, woff2, variant)}");
                    Uri url = new(propertyValue);

                    if (!File.Exists(FileName))
                    {
                        await DownloadFileAsync(url, FileName);
                    }
                }
                else
                {  
                    Console.WriteLine("Download link is empty");
                }
            }
        }
        private async Task DownloadFileAsync(Uri url, string fileName)
        {
            try
            {
                var response = await httpClient.GetAsync(url).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                using var stream = await response.Content.ReadAsStreamAsync();
                using var fileStream = File.Create(fileName);
                await stream.CopyToAsync(fileStream).ConfigureAwait(false);
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
        public void Dispose() => httpClient?.Dispose();
    }
}
