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
        private bool disposed = false;

        public FontFilesDownloader()
        {
            httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromMinutes(5)
            };
        }

        public async Task DownloadAsync(Item selectedFont, string folderName, bool woff2)
        {
            if (selectedFont == null || string.IsNullOrEmpty(folderName))
                throw new ArgumentException("Font or folder name cannot be null");

            foreach (var variant in selectedFont.Variants.Select(v => v.Replace(" ", "")))
            {
                var fontFileStyle = Helper.GetFontFileStyles(variant) ?? variant;
                var propertyValue = selectedFont.Files.GetType().GetProperty($"_{Helper.MapVariant(variant)}")?.GetValue(selectedFont.Files) as string;

                if (!string.IsNullOrEmpty(propertyValue))
                {
                    string fontFolderPath = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""));
                    Directory.CreateDirectory(fontFolderPath); // Ensure directory exists

                    string fileName = Path.Combine(fontFolderPath, Helper.FontFileName(selectedFont.Family, woff2, variant));

                    if (!File.Exists(fileName))
                    {
                        await DownloadFileAsync(new Uri(propertyValue), fileName);
                    }
                }
                else
                {
                    Logger.HandleError("Download link is empty", new Exception($"Missing download link for variant {variant}"));
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
                Logger.HandleError($"Error downloading font file from {url}", ex);
                throw;
            }
            catch (IOException ex)
            {
                Logger.HandleError($"Error saving font file to {fileName}", ex);
                throw;
            }
            catch (Exception ex)
            {
                Logger.HandleError("Unexpected error during download", ex);
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    httpClient?.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}