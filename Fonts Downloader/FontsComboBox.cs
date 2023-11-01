using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsComboBox
    {
        private static List<Item> FontsList = new();
        public static async Task<List<Item>> GetWebFontsAsync(string apiKey, bool Woff2)
        {      
            try
            {
                var WOFF = Woff2 ? "capability=WOFF2" : "";
                var link = $"https://www.googleapis.com/webfonts/v1/webfonts?{WOFF}&sort=alpha&key={apiKey}";
                var result = await Api.Get(link);
                //if (result.Success)
                //{
                //    var fontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                //    FontsList = fontResponse.Items;
                //}
                if (result.Success)
                {
                    var fontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                    if (!FontsList.Any() && fontResponse.Items.Any() && fontResponse != null)
                        FontsList = fontResponse.Items;
                    else
                    {
                        FontsList = FontsList.Zip(fontResponse.Items, (existingItem, newItem) =>
                        {
                            existingItem.Files = newItem.Files;
                            return existingItem;
                        }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }

            return FontsList;
        }
    }
}
