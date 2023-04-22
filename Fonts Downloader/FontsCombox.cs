using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsCombox
    {
        private List<string> links_100 = new List<string>();
        public List<string> Links_100
        {
            get
            {
                return this.links_100;
            }
            set
            {
                this.links_100 = value;
            }
        }

        private List<string> links_100italic = new List<string>();
        public List<string> Links_100italic
        {
            get
            {
                return this.links_100italic;
            }
            set
            {
                this.links_100italic = value;
            }
        }

        private List<string> links_200 = new List<string>();
        public List<string> Links_200
        {
            get
            {
                return links_200;
            }
            set
            {
                this.links_200 = value;
            }
        }

        private List<string> links_200italic = new List<string>();
        public List<string> Links_200italic
        {
            get
            {
                return links_200italic;
            }
            set
            {
                this.links_200italic = value;
            }
        }

        private List<string> links_300 = new List<string>();
        public List<string> Links_300
        {
            get
            {
                return links_300;
            }
            set
            {
                this.links_300 = value;
            }
        }

        private List<string> links_300italic = new List<string>();

        public List<string> Links_300italic
        {
            get
            {
                return links_300italic;
            }
            set
            {
                this.links_300italic = value;
            }
        }

        private List<string> links_regular = new List<string>();

        public List<string> Links_regular
        {
            get
            {
                return links_regular;
            }
            set
            {
                this.links_regular = value;
            }
        }

        private List<string> links_italic = new List<string>();
        public List<string> Links_italic
        {
            get
            {
                return this.links_italic;
            }
            set
            {
                this.links_italic = value;
            }
        }

        private List<string> links_500 = new List<string>();
        public List<string> Links_500
        {
            get
            {
                return links_500;
            }
            set
            {
                this.links_500 = value;
            }
        }

        private List<string> links_500italic = new List<string>();
        public List<string> Links_500italic
        {
            get
            {
                return links_500italic;
            }
            set
            {
                this.links_500italic = value;
            }
        }


        private List<string> links_600 = new List<string>();
        public List<string> Links_600
        {
            get
            {
                return links_600;
            }
            set
            {
                this.links_600 = value;
            }
        }

        private List<string> links_600italic = new List<string>();
        public List<string> Links_600italic
        {
            get
            {
                return links_600italic;
            }
            set
            {
                this.links_600italic = value;
            }
        }

        private List<string> links_700 = new List<string>();
        public List<string> Links_700
        {
            get
            {
                return links_700;
            }
            set
            {
                this.links_700 = value;
            }
        }

        private List<string> links_700italic = new List<string>();
        public List<string> Links_700italic
        {
            get
            {
                return links_700italic;
            }
            set
            {
                this.links_700italic = value;
            }
        }

        private List<string> links_800 = new List<string>();
        public List<string> Links_800
        {
            get
            {
                return links_800;
            }
            set
            {
                this.links_800 = value;
            }
        }

        private List<string> links_800italic = new List<string>();
        public List<string> Links_800italic
        {
            get
            {
                return links_800italic;
            }
            set
            {
                this.links_800italic = value;
            }
        }

        private List<string> links_900 = new List<string>();
        public List<string> Links_900
        {
            get
            {
                return links_900;
            }
            set
            {
                this.links_900 = value;
            }
        }

        private List<string> links_900italic = new List<string>();
        public List<string> Links_900italic
        {
            get
            {
                return links_900italic;
            }
            set
            {
                this.links_900italic = value;
            }
        }

        private List<Item> allList = new List<Item>();
        private List<string> Subset = new List<string>();
        public List<Item> AllList { get { return allList; } }
        public List<string> SubsetList { get { return Subset; } }
        public async Task resAsync(ComboBox FontBox, string Key)
        {
            var result = await Api.Get($@"https://www.googleapis.com/webfonts/v1/webfonts?sort=alpha&key={Key}");
            if (result.Success)
            {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                Root FontResponse = JsonConvert.DeserializeObject<Root>(result.Response);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                foreach (var list in FontResponse.items)
                {
                    allList.Add(list);
                    if (!string.IsNullOrEmpty(list.files._100))
                        links_100.Add(list.files._100);

                    if (!string.IsNullOrEmpty(list.files._100italic))
                        links_100italic.Add(list.files._100italic);

                    if (!string.IsNullOrEmpty(list.files._200))
                        links_200.Add(list.files._200);

                    if (!string.IsNullOrEmpty(list.files._200italic))
                        links_200italic.Add(list.files._200italic);

                    if (!string.IsNullOrEmpty(list.files._300))
                        links_300.Add(list.files._300);

                    if (!string.IsNullOrEmpty(list.files._300italic))
                        links_300italic.Add(list.files._300italic);

                    if (!string.IsNullOrEmpty(list.files.regular))
                        links_regular.Add(list.files.regular);

                    if (!string.IsNullOrEmpty(list.files.italic))
                        links_italic.Add(list.files.italic);

                    if (!string.IsNullOrEmpty(list.files._500))
                        links_500.Add(list.files._500);

                    if (!string.IsNullOrEmpty(list.files._500italic))
                        links_500italic.Add(list.files._500italic);

                    if (!string.IsNullOrEmpty(list.files._600))
                        links_600.Add(list.files._600);

                    if (!string.IsNullOrEmpty(list.files._600italic))
                        links_600italic.Add(list.files._600italic);


                    if (!string.IsNullOrEmpty(list.files._700))
                        links_700.Add(list.files._700);

                    if (!string.IsNullOrEmpty(list.files._700italic))
                        links_700italic.Add(list.files._700italic);

                    if (!string.IsNullOrEmpty(list.files._800))
                        links_800.Add(list.files._800);

                    if (!string.IsNullOrEmpty(list.files._800italic))
                        links_800italic.Add(list.files._800italic);

                    if (!string.IsNullOrEmpty(list.files._900))
                        links_900.Add(list.files._900);

                    if (!string.IsNullOrEmpty(list.files._900italic))
                        links_900italic.Add(list.files._900italic);

                }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                for (int i = 0; i < allList.Count; i++)
                {
                    FontBox.Items.Add(allList[i].family);
                }
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}