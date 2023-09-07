using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsComboBoxx
    {
        private readonly List<Item> fontsList = new List<Item>();
        public async Task<List<Item>> ResAsync(string Key)
        {
            var result = await Api.Get($@"https://www.googleapis.com/webfonts/v1/webfonts?sort=alpha&key={Key}");
            if (result.Success)
            {
                Root FontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
                foreach (var list in FontResponse.items)
                {
                    fontsList.Add(list);
                }
            }
            else
                MessageBox.Show(result.Message);
            return fontsList;
        }
    }
}