using Fonts_Downloader;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class WebFonts
    {
        public Root FontResponse { private set; get; }
        public bool Succeeded { private set; get; }

        public async Task<List<Item>> GetWebFontsAsync(string apiKey, bool woff2)
        {
            try
            {
                var woffQuery = woff2 ? "capability=WOFF2" : "";
                var link = $"https://www.googleapis.com/webfonts/v1/webfonts?{woffQuery}&sort=alpha&key={apiKey}";
                var result = await GetAsync(link);

                if (!Succeeded) // Check if the request was unsuccessful
                {
                    return [];
                }

                // Deserialize and check for errors in the response
                FontResponse = JsonConvert.DeserializeObject<Root>(result);
                if (FontResponse.Error != null)
                {
                    Logger.HandleError($"API Error: {FontResponse.Error.Message}", new Exception($"API Error Code: {FontResponse.Error.Code}"));
                    MessageBox.Show($"API Error: {FontResponse.Error.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return [];
                }

                return FontResponse.Items;
            }
            catch (HttpRequestException httpRequestException)
            {
                Logger.HandleError("Network error occurred.", httpRequestException);
#if DEBUG
                MessageBox.Show("Network error occurred. Please check your internet connection.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif                
                return [];
            }
            catch (Exception ex)
            {
                Logger.HandleError("An error occurred while fetching web fonts.", ex);
#if DEBUG
                MessageBox.Show("An unexpected error occurred.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
#endif
                return [];
            }
        }

        private async Task<string> GetAsync(string url)
        {
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Succeeded = true;
                    return await response.Content.ReadAsStringAsync();
                }

                // Check if the error is related to the API key
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized ||
                    response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    Logger.HandleError("API key is invalid or unauthorized.", new Exception(response.ReasonPhrase));
                    MessageBox.Show("Invalid API key. Please check your API key and try again.", "API Key Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // Handle other HTTP errors
                    Logger.HandleError($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}", new Exception(response.ReasonPhrase));                 
                }

                Succeeded = false;
                return string.Empty;
            }
            catch (HttpRequestException)
            {
                Succeeded = false;
                throw; // Re-throw to be caught in the calling method
            }
        }
    }
}

