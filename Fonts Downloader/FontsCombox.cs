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
        public Dictionary<string, List<string>> LinksByVariantNormal { get; } = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> LinksByVariantItalic { get; } = new Dictionary<string, List<string>>();
        private void AddLinkForVariant(string variant, string link)
        {
            var targetDictionary = variant.Contains("italic") ? LinksByVariantItalic : LinksByVariantNormal;

            if (!targetDictionary.ContainsKey(variant))
            {
                targetDictionary[variant] = new List<string>();
            }

            targetDictionary[variant].Add(link);
        }

        private List<Item> allList = new List<Item>();
        private List<string> Subset = new List<string>();
        public List<Item> AllList => allList;
        public List<string> SubsetList => Subset;

        public async Task resAsync(ComboBox FontBox, string Key)
        {
            var result = await Api.Get($@"https://www.googleapis.com/webfonts/v1/webfonts?sort=alpha&key={Key}");
            if (result.Success)
            {
                Root FontResponse = JsonConvert.DeserializeObject<Root>(result.Response);

                foreach (var list in FontResponse.items)
                {
                    FontBox.Items.Add(list.family);
                    allList.Add(list);

                    foreach (var variant in variants)
                    {
                        var propertyName = variant == "regular" || variant == "italic" ? variant : $"_{variant}";
                        var propertyValue = (string)list.files.GetType().GetProperty(propertyName)?.GetValue(list.files);

                        if (!string.IsNullOrEmpty(propertyValue))
                        {
                            AddLinkForVariant(variant, propertyValue);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}
