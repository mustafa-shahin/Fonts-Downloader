using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public class FontsCombox
    {
        private List<string> links100 = new List<string>();
        public List<string> Links100 { get => links100; set => links100 = value; }

        private List<string> links100Italic = new List<string>();
        public List<string> Links100Italic { get => links100Italic; set => links100Italic = value; }

        private List<string> links200 = new List<string>();
        public List<string> Links200 { get => links200; set => links200 = value; }

        private List<string> links200Italic = new List<string>();
        public List<string> Links200Italic { get => links200Italic; set => links200Italic = value; }

        private List<string> links300 = new List<string>();
        public List<string> Links300 { get => links300; set => links300 = value; }

        private List<string> links300Italic = new List<string>();
        public List<string> Links300Italic { get => links300Italic; set => links300Italic = value; }

        private List<string> links400 = new List<string>();
        public List<string> Links400 { get => links400; set => links400 = value; }

        private List<string> links400Italic = new List<string>();
        public List<string> Links400Italic { get => links400Italic; set => links400Italic = value; }

        private List<string> links500 = new List<string>();
        public List<string> Links500 { get => links500; set => links500 = value; }

        private List<string> link500Italic = new List<string>();
        public List<string> Links500Italic { get => link500Italic; set => link500Italic = value; }

        private List<string> links600 = new List<string>();
        public List<string> Links600 { get => links600; set => links600 = value; }

        private List<string> links600Italic = new List<string>();
        public List<string> Links600Italic { get => links600Italic; set => links600Italic = value; }


        private List<string> links700 = new List<string>();
        public List<string> Links700 { get => links700; set => links700 = value; }

        private List<string> links700Italic = new List<string>();
        public List<string> Links700Italic { get => links700Italic; set => links700Italic = value; }

        private List<string> links800 = new List<string>();
        public List<string> Links800 { get => links800; set => links800 = value; }

        private List<string> links800Italic = new List<string>();
        public List<string> Links800Italic { get => links800Italic; set => links800Italic = value; }

        private List<string> links900 = new List<string>();
        public List<string> Links900 { get => links900; set => links900 = value; }

        private List<string> links900Italic = new List<string>();
        public List<string> Links900Italic { get => links700Italic; set => links900Italic = value; }
       
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
                    
                    /*+*+*+*+*+*+*+*+*+*Normal Fonts*+*+*+*+*+*+*+*+*+*/
                    if (!string.IsNullOrEmpty(list.files._100))
                        links100.Add(list.files._100);

                    if (!string.IsNullOrEmpty(list.files._200))
                        links200.Add(list.files._200);

                    if (!string.IsNullOrEmpty(list.files._300))
                        links300.Add(list.files._300);

                    if (!string.IsNullOrEmpty(list.files.regular))
                        links400.Add(list.files.regular);

                    if (!string.IsNullOrEmpty(list.files._500))
                        links500.Add(list.files._500);

                    if (!string.IsNullOrEmpty(list.files._600))
                        links600.Add(list.files._600);

                    if (!string.IsNullOrEmpty(list.files._700))
                        links700.Add(list.files._700);

                    if (!string.IsNullOrEmpty(list.files._800))
                        links800.Add(list.files._800);

                    if (!string.IsNullOrEmpty(list.files._900))
                        links900.Add(list.files._900);


                    /*+*+*+*+*+*+*+*+*+*Italic Fonts*+*+*+*+*+*+*+*+*+*/
                    if (!string.IsNullOrEmpty(list.files._100italic))
                        links100Italic.Add(list.files._100italic);
                    
                    if (!string.IsNullOrEmpty(list.files._200italic))
                        links200Italic.Add(list.files._200italic);

                    if (!string.IsNullOrEmpty(list.files._300italic))
                        links300Italic.Add(list.files._300italic);

                    if (!string.IsNullOrEmpty(list.files.italic))
                        links400Italic.Add(list.files.italic);

                    if (!string.IsNullOrEmpty(list.files._500italic))
                        link500Italic.Add(list.files._500italic);

                    if (!string.IsNullOrEmpty(list.files._600italic))
                        links600Italic.Add(list.files._600italic);

                    if (!string.IsNullOrEmpty(list.files._700))
                        links700.Add(list.files._700);

                    if (!string.IsNullOrEmpty(list.files._800))
                        links800.Add(list.files._800);

                    if (!string.IsNullOrEmpty(list.files._900))
                        links900.Add(list.files._900);

                    if (!string.IsNullOrEmpty(list.files._900italic))
                        links900Italic.Add(list.files._900italic);

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