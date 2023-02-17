using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class HtmlFile
    {
        private List<string> WgtItalic = new List<string>();
        private List<string> WgtNormal = new List<string>();
        private string HeadStart = "<head>";
        private string HeadEnd = "</head>";
        private string StyleTagStart = "<style>";
        private string StyleTagEnd = "</style>";
        private string H1TagStart = "<h1>";
        private string H1TagEnd = "</h1>";
        private string P_TagStart = "<p class=";
        private string P_TagEnd = "</p>";
        public void CreateHtml(Label SelectedFont, CheckedListBox SizeAndStyle, string FolderName)
        {
            foreach (var variant in SizeAndStyle.Items)
            {
                if (!variant.ToString().Contains("italic"))
                {
                    WgtNormal.Add(variant.ToString());

                }
                else
                {
                    WgtItalic.Add(variant.ToString().Replace("italic", ""));
                }
            }
            string PTagItalic, PTagNormal, html;
            string Italics = string.Join(";", WgtItalic);
            string Normals = string.Join(";", WgtNormal);
            string GoogleFontLinkItalics = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont.Text}:wght@{Italics}&display=swap\" rel=\"stylesheet\">";
            string GoogleFontLinkItalicsNormals = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont.Text}:wght@{Normals}&display=swap\" rel=\"stylesheet\">";
            List<string> PTag = new List<string>();
            List<string> styles = new List<string>();
            if (WgtItalic.Any())
            {
                foreach (string wgt in WgtItalic)
                {
                    PTagItalic = "\np." + "size" + $"{wgt}" + "italic" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: italic;\n" + "font-weight:" + $"{wgt};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTag.Add(PTagItalic);
                }
            }
            if (WgtNormal.Any())
            {
                foreach (string wgt in WgtNormal)
                {
                    PTagNormal = "\np." + "size" + $"{wgt}" + "italic" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: normal;\n" + "font-weight:" + $"{wgt};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTag.Add(PTagNormal);
                }
            }

            using (StreamWriter writer = new StreamWriter($"{FolderName}\\{SelectedFont.Text.Replace(" ", "")}\\{SelectedFont.Text.Replace(" ", "")}.html", false))
            {
                for (int i = 0; i < PTag.Count; i++)
                {
                    if (i == 0)
                    {
                        writer.WriteLine(HeadStart);
                        if (!string.IsNullOrEmpty(Italics))
                        {
                            writer.WriteLine(GoogleFontLinkItalics);
                        }
                        if (!string.IsNullOrEmpty(Normals))
                        {
                            writer.WriteLine(GoogleFontLinkItalicsNormals);
                        }
                        writer.WriteLine(HeadEnd + "\n" + StyleTagStart);
                    }
                    writer.WriteLine(PTag[i]);
                    if(i==PTag.Count-1) 
                    {
                        writer.WriteLine(StyleTagEnd);
                    }
                }
            }
        }
    }
}
