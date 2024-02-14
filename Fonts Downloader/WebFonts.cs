using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class WebFonts
    {

        private Root _Error;
        public async Task<List<Item>> GetWebFontsAsync(string apiKey, bool Woff2)
        {
            var FontsList = new List<Item>();
            try
            {
                var WOFF = Woff2 ? "capability=WOFF2" : "";
                var link = $"https://www.googleapis.com/webfonts/v1/webfonts?{WOFF}&sort=alpha&key={apiKey}";
                var result = await Api.Get(link);
                var FontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                if (FontResponse.Items != null)
                {
                    if (FontResponse is not null && FontResponse.Items.Any() && !FontsList.Any() && FontResponse.Error == null)
                        FontsList = FontResponse.Items;
                    else
                    {
                        FontsList = FontsList.Zip(FontResponse.Items, (existingItem, newItem) =>
                        {
                            existingItem.Files = newItem.Files;
                            return existingItem;
                        }).ToList();
                    }
                }
                else
                    _Error = FontResponse;

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            return FontsList;
        }

        public Root Error
        {
            set { _Error = value; }
            get {return _Error;}
        }
    }
}
