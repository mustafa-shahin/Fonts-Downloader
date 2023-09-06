using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsCombox
    {
        private readonly string[] variants = new string[]
        {
            "100", "100italic", "200", "200italic", "300", "300italic",
            "400", "400italic", "500", "500italic", "600", "600italic",
            "700", "700italic", "800", "800italic", "900", "900italic"
        };
        private readonly List<Item> fontsList = new List<Item>();
        public async Task<List<Item>> resAsync(string Key)
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