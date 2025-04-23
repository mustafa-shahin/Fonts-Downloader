using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class WebFonts
    {
        public Root FontResponse { get; private set; }
        public bool Succeeded { get; private set; }
        private readonly HttpClient _httpClient;

        public WebFonts()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        public async Task<List<Item>> GetWebFontsAsync(string apiKey, bool woff2)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("Please enter a valid Google Fonts API key", "API Key Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return [];
            }

            try
            {
                var woffQuery = woff2 ? "capability=WOFF2" : "";
                var link = $"https://www.googleapis.com/webfonts/v1/webfonts?{woffQuery}&sort=alpha&key={apiKey}";
                var result = await GetAsync(link);

                if (!Succeeded)
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

                return FontResponse.Items ?? [];
            }
            catch (HttpRequestException httpRequestException)
            {
                Logger.HandleError("Network error occurred.", httpRequestException);
                MessageBox.Show("Network error occurred. Please check your internet connection.", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
            catch (Exception ex)
            {
                Logger.HandleError("An error occurred while fetching web fonts.", ex);
                MessageBox.Show("An unexpected error occurred while fetching fonts.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        private async Task<string> GetAsync(string url)
        {
            try
            {
                var response = await _httpClient.GetAsync(url);

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
                    MessageBox.Show($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Succeeded = false;
                return string.Empty;
            }
            catch (HttpRequestException ex)
            {
                Succeeded = false;
                Logger.HandleError("HTTP Request Error", ex);
                throw;
            }
            catch (TaskCanceledException ex)
            {
                Succeeded = false;
                Logger.HandleError("Request timeout", ex);
                MessageBox.Show("The request to Google Fonts API timed out. Please try again later.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return string.Empty;
            }
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}