using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class WebFonts
    {
        public Root FontResponse  {private set; get;}
        public  bool Succeeded { private set; get; }
        public async Task<List<Item>> GetWebFontsAsync(string apiKey, bool woff2)
        {          
            try
            {
                var woffQuery = woff2 ? "capability=WOFF2" : "";
                var link = $"https://www.googleapis.com/webfonts/v1/webfonts?{woffQuery}&sort=alpha&key={apiKey}";
                var result = await GetAsync(link);
                FontResponse = JsonConvert.DeserializeObject<Root>(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return FontResponse.Items;
        }
        private async Task<string> GetAsync(string url)
        {
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);
                Succeeded = response.IsSuccessStatusCode;
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException httpRequestException)
            {
                Succeeded = false;
                MessageBox.Show($"Request error: {httpRequestException.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }
    }
}
