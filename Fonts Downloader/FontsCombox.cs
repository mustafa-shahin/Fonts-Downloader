using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        private Dictionary<string, List<string>> _LinksByVariantNormal = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> _LinksByVariantItalic = new Dictionary<string, List<string>>();
        public Dictionary<string, List<string>> LinksByVariantNormal { set { this._LinksByVariantNormal = value; } get { return this._LinksByVariantNormal; } }
        public Dictionary<string, List<string>> LinksByVariantItalic { set { this._LinksByVariantItalic = value; } get { return this._LinksByVariantItalic; } }
        private void AddLinkForVariant(string variant, string link)
        {
            var targetDictionary = variant.Contains("italic") ? _LinksByVariantItalic : _LinksByVariantNormal;

            if (!targetDictionary.ContainsKey(variant))
            {
                targetDictionary[variant] = new List<string>();
            }

            targetDictionary[variant].Add(link);
        }

        private readonly List<Item> allList = new List<Item>();

        private readonly List<string> Subset = new List<string>();
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
                        if (!string.IsNullOrEmpty(propertyName))
                        {
                            string propertyValue = (string)list.files.GetType().GetProperty(propertyName)?.GetValue(list.files);
                            if (!string.IsNullOrEmpty(propertyValue))
                            {
                                AddLinkForVariant(variant, propertyValue);
                            }
                            else
                                continue;
                        }
                        else
                            MessageBox.Show($"The property {propertyName} does not exist");
                    }
                }
            }
            else
                MessageBox.Show(result.Message);
        }
    }
}