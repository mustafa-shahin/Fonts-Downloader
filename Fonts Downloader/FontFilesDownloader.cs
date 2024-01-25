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
        public async Task Download(Item selectedFont, string folderName, bool woff2)
        {
            foreach (var variant in selectedFont.Variants.Select(variant => variant.Replace(" ", "")))
            {
                var FontStyle = variant.Contains("italic") ? "italic" : "normal";
                var FontFileStyle = FontFileStyles.GetFontFileStyles(variant) ?? variant;
                var PropertyValue = selectedFont.Files.GetType().GetProperty($"_{FontFileStyles.MapVariant(variant)}")?.GetValue(selectedFont.Files) as string;
                if (!string.IsNullOrEmpty(PropertyValue))
                {
                    string FileName = Path.Combine(folderName, selectedFont.Family.Replace(" ", ""), $"{FontFileStyles.FontFileName(selectedFont.Family, woff2, variant)}");
                    Uri Url = new(PropertyValue);
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
                else
                    MessageBox.Show("Download link is empty");
            }
        }
    }
}
