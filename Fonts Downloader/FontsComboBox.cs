using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsComboBox
    {
        private List<Item> fontsList = new List<Item>();

        public async Task<List<Item>> GetWebFontsAsync(string apiKey, bool Woff2, bool TTF)
        {
            string link = string.Empty;

            try
            {
                if (Woff2)
                {
                    link = $"https://www.googleapis.com/webfonts/v1/webfonts?capability=WOFF2&sort=alpha&key={apiKey}";
                }

                else if (TTF)
                {
                    link = $"https://www.googleapis.com/webfonts/v1/webfonts?sort=alpha&key={apiKey}";
                }
                var result = await Api.Get(link);

                if (result.Success)
                {
                    var fontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                    fontsList = fontResponse.Items;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return fontsList;
        }
    }
}
