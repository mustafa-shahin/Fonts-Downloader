using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        private List<string> FontWeights = new List<string>();
        private List<string> _Styles = new List<string>();
        public List<string> Styles { get { return _Styles; } }

        private readonly string Fontface = "@font-face {";
        private readonly string Fontfamily = "\nfont-family:";
        private string fontStyle = "\nfont-style:";
        private readonly string fontweight = "\nfont-weight:";
        private string _FontStyle;
        private string OldFont;

        public string FontFace { get { return Fontface; } }
        public string FontFamily { get { return Fontfamily; } }
        public string Fontstyle { get { return fontStyle; } }
        public string FontStyles { set { this._FontStyle = value; } get { return this._FontStyle; } }
        public List<string> FontWeight { get { return FontWeights; } }
        public void CreateCSS(CheckedListBox SizeAndStyle, List<string> SubSet, string FolderName, string FontName)
        {
            var FontFileStyles = new Dictionary<string, string>
            {
                    { "100", "Thin" },
                    { "200", "ExtraLight" },
                    { "300", "Light" },
                    { "400", "Regular" },
                    { "500", "Medium" },
                    { "600", "SemiBold" },
                    { "700", "ExtraBold" },
                    { "800", "ExtraBold" },
                    { "900", "Black" },
            };
            string FontFileStyle="";
            var Css = new List<string>();
            if (FontWeights.Any())
            {
                FontWeights.Clear();
            }
            if (SizeAndStyle.CheckedItems.Count != 0)
            {
                for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
                {
                     _FontStyle = SizeAndStyle.CheckedItems[i].ToString().Contains("italic") ? "italic" : "normal";
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
                        if (FontFileStyles.ContainsKey(FontWeight[i]))
                        {
                                    FontFileStyle = FontFileStyles[(FontWeight[i])];
                        }                       
                        foreach (var sub in SubSet)
                        {
                            string css = $"/*{sub}*/" + "\n" + FontFace + FontFamily + $"'{FontName}';" + $"{fontStyle}" + $"{_FontStyle};" + $"{fontweight}" + $"{FontWeights[i]};" 
                                + "\r\nfont-stretch: 100%;" + "\r\n" + $"src: url('{FontName.Replace(" ", "")}-{_FontStyle.Substring(0, 1).ToUpper() + _FontStyle.Substring(1)}-{FontFileStyle}.ttf')" + "\r\n}";
                            Css.Add(css);
                        }
                        if (i == SizeAndStyle.CheckedItems.Count)
                        {
                            break;
                        }
                    }
                }
            }
            if(FontWeight.Any())
            {
                Directory.CreateDirectory($"{FolderName}\\{FontName.Replace(" ", "")}");
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
}
