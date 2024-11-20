using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class FontFilesDownloader : IDisposable
    {
        private readonly HttpClient httpClient;

        public FontFilesDownloader()
        {
            httpClient = new HttpClient();
        }

        public async Task DownloadAsync(Item selectedFont, string folderName, bool woff2)
        {
            foreach (var variant in selectedFont.Variants.Select(v => v.Replace(" ", "")))
            {
                var fontFileStyle = Helper.GetFontFileStyles(variant) ?? variant;
                var propertyValue = selectedFont.Files.GetType().GetProperty($"_{Helper.MapVariant(variant)}")?.GetValue(selectedFont.Files) as string;

                if (!string.IsNullOrEmpty(propertyValue))
                {
                    string fileName = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""), $"{Helper.FontFileName(selectedFont.Family, woff2, variant)}");
                    Uri url = new(propertyValue);

                    if (!File.Exists(fileName))
                    {
                        await DownloadFileAsync(url, fileName);
                    }
                }
                else
                {
                    Logger.HandleError("Download link is empty", new Exception("The download link is empty or invalid."));
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
                Logger.HandleError("Error downloading font file.", ex);
            }
            catch (IOException ex)
            {
                Logger.HandleError("Error saving font file.", ex);
            }
        }

        public void Dispose() => httpClient?.Dispose();
    }

}
