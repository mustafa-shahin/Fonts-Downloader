using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class CSS
    {
        private string[] FontFileStyles = { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" };
        private List<string> FontWeights = new List<string>();
        private List<string> _Styles = new List<string>();
        public List<string> Styles { get { return _Styles; } }
        private string Fontface = "@font-face {", Fontfamily = "\nfont-family:", fontStyle = "\nfont-style:", fontweight = "\nfont-weight:", _FontStyle, OldFont;
        public string FontFace { get { return Fontface; } }
        public string FontFamily { get { return Fontfamily; } }
        public string Fontstyle { get { return fontStyle; } }
        public string FontStyles { set { this._FontStyle = value; } get { return this._FontStyle; } }
        public List<string> FontWeight { get { return FontWeights; } }
        public void CreateCSS(CheckedListBox SizeAndStyle, List<string> SubSet, string FolderName, string FontName, string FontFileStyle)
        {
            List<string> Css = new List<string>();
            if (FontWeights.Any())
            {
                FontWeights.Clear();
            }
            if (SizeAndStyle.CheckedItems.Count != 0)
            {
                for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
                {
                    if (!SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                    {
                        _FontStyle = "normal";

                    }
                    else if (SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                    {
                        _FontStyle = "italic";

                    }
                    if (!SizeAndStyle.CheckedItems[i].Equals(false))
                    {
                        _Styles.Add(_FontStyle);
                        FontWeights.Add(SizeAndStyle.CheckedItems[i].ToString().Replace("italic", ""));
                    }
                    else
                    {

                        FontWeights.Remove(SizeAndStyle.CheckedItems[i].ToString());
                    }
                    OldFont = FontName;
                    if (FontName != OldFont)
                    {
                    }
                    else
                    {
                        for (int j = 0; j <= FontWeights.Count; j++)
                        {
                            if (FontWeights[i] == "100")
                                FontFileStyle = FontFileStyles[0];

                            else if (FontWeights[i] == "200")
                                FontFileStyle = FontFileStyles[1];

                            else if (FontWeights[i] == "300")
                                FontFileStyle = FontFileStyles[2];

                            else if (FontWeights[i] == "400")
                                FontFileStyle = FontFileStyles[3];
                            else if (FontWeights[i] == "500")
                                FontFileStyle = FontFileStyles[4];

                            else if (FontWeights[i] == "600")
                                FontFileStyle = FontFileStyles[5];

                            else if (FontWeights[i] == "700")
                                FontFileStyle = FontFileStyles[6];

                            else if (FontWeights[i] == "800")
                                FontFileStyle = FontFileStyles[7];

                            else if (FontWeights[i] == "900")
                                FontFileStyle = FontFileStyles[8];
                        }
                        foreach (var sub in SubSet)
                        {
                            string css = $"/*{sub}*/" + "\n" + FontFace + FontFamily + $"'{FontName}';" + $"{fontStyle}" + $"{_FontStyle};" + $"{fontweight}" + $"{FontWeights[i]};" + "\r\nfont-stretch: 100%;" + "\r\n" + $"src: url('{FontName.Replace(" ", "")}-{_FontStyle.Substring(0, 1).ToUpper() + _FontStyle.Substring(1)}-{FontFileStyle}.ttf')" + "\r\n}";
                            Css.Add(css);
                        }
                        if (i == SizeAndStyle.CheckedItems.Count)
                        {
                            break;
                        }
                    }
                }
            }
            using (StreamWriter writer = new StreamWriter($"{FolderName}\\{FontName.Replace(" ", "")}\\{FontName.Replace(" ", "")}.css", false))
            {
                foreach (var str in Css)
                {
                    writer.WriteLine(str);
                }
            }
        }
    }
}
