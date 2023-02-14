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

        private string StyleTagStart = "<style>";
        private string StyleTagEnd = "</style>";
        private string H1TagStart = "<h1>";
        private string H1TagEnd = "</h1>";
        private string P_TagStart = "<p class=";
        private string P_TagEnd = "</p>";
        private string Class = "class = ";
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
                        //foreach (var size in FontWeights)
                        //{
                        //    string html = $"{StyleTagStart}" + $"\n p.size" + "{" + FontFamily + $"'{FontName}';" + $"{fontStyle}" + $"{_FontStyle};" + $"{fontweight}" + $"{FontWeights[i]};" + "\r\nfont-stretch: 100%;" + "\r\n" + "}";
                        //    stylescc.Add(html);
                        //}
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
            //using (StreamWriter writer = new StreamWriter($"{FolderName}\\{FontName.Replace(" ", "")}\\{FontName.Replace(" ", "")}.html", false))
            //{
            //    foreach (var str in stylescc)
            //    {
            //        writer.WriteLine(str);
            //    }
            //}
            //using (StreamWriter writer = new StreamWriter($"{FolderName}\\{FontName.Replace(" ", "")}\\{FontName.Replace(" ", "")}.css", false))
            //{
            //    foreach (var str in Css)
            //    {
            //        writer.WriteLine(str);
            //    }
            //}
        }
        public void CreateHtml(CheckedListBox SizeAndStyle, string FolderName, string FontName)
        {
            List<string> PTag = new List<string>();
            List<string> styles = new List<string>();
            if (FontWeights.Any() || _Styles.Any())
            {
                FontWeights.Clear();
                _Styles.Clear();
            }
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
                if (FontName != OldFont)
                {
                }
                else
                {
                    string html = "\np." + "size" + $"{FontWeights[i]}{_FontStyle}" + "{" + $"{FontFamily}" + $"'{FontName}';" + $"{fontStyle}" + $"{_FontStyle};" + $"{fontweight}" + $"{FontWeights[i]};" + "\r\nfont-stretch: 100%;" + "\n}\n";
                    string pTag = "<p " +"class =\"" + "size"+ $"{FontWeights[i]}{_FontStyle}\">"+ $"{FontName}: " + "Whereas recognition of the inherent dignity" +"</p>";
                    if (i == 0) { html = StyleTagStart + html; }                   
                    styles.Add(html);
                    PTag.Add(pTag);
                }

            }



            using (StreamWriter writer1 = new StreamWriter($"{FolderName}\\{FontName.Replace(" ", "")}\\{FontName.Replace(" ", "")}.html", false))
            {
                for (int i = 0; i < styles.Count;i++)
                {
                    writer1.WriteLine(styles[i]);
                    if(i == styles.Count - 1) { writer1.WriteLine(StyleTagEnd); }
                }
                for (int i = 0; i < styles.Count; i++)
                {
                    writer1.WriteLine(PTag[i]);
                }
            }
        }
    }
}

/*
 
              
                for (int j = 0; j < FontWeights.Count; j++)
                {
                if (!SizeAndStyle.CheckedItems[j].ToString().Contains("italic"))
                {
                    _FontStyle = "normal";

                }
                else if (SizeAndStyle.CheckedItems[j].ToString().Contains("italic"))
                {
                    _FontStyle = "italic";

                }
                if (!SizeAndStyle.CheckedItems[j].Equals(false))
                {
                   
                    FontWeights.Add(SizeAndStyle.CheckedItems[j].ToString().Replace("italic", ""));
                }
                else
                {

                    FontWeights.Remove(SizeAndStyle.CheckedItems[j].ToString());
                }
                if (FontName != OldFont)
                    {
                    }
                    else
                    {
                        string html = $"\np." + "size" + $"{FontWeights[j]}" + "{" + $"{FontFamily}" + $"'{FontName}';" + $"{fontStyle}" + $"{_FontStyle};" + $"{fontweight}" + $"{FontWeights[j]};" + "\r\nfont-stretch: 100%;" + "\n}\n";
                        if (j == 0) { html = StyleTagStart + html; }
                        if (j == FontWeights.Count - 1) { html += StyleTagEnd; }
                        styles.Add(html);
                    }

                }
 
 
 
 
 */