﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
                var fontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                if (fontResponse.Items != null)
                {
                    if (!FontsList.Any() && fontResponse.Items.Any() && fontResponse.Error == null)
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
                else
                {
                    var Path = @"C:\FontDownloader";
                    var Error = $"<html><body>\n<h1 style=\"color:#9b2b22;text-align: center;\">{fontResponse.Error.Message}</h1>\n</body>\n</html>";
                    using var Writer = new StreamWriter($"{Path}\\index.html", false);
                    Writer.WriteLine(Error, false);
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
