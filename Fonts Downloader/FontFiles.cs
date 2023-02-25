using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Fonts_Downloader
{
    internal class FontFiles
    {

        public void FileLinks(CheckedListBox SizeAndStyle, string FontStyle, List<string> FontWeight, string FontFileStyle, string[] FontFileStyles, Label SelectedFont, string FolderName, string FontName, FontsCombox Res)
        {
            for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
            {
                if (!SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                {
                    FontStyle = "normal";
                }
                else if (SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                {
                    FontStyle = "italic";
                }
                for (int j = 0; j <= FontWeight.Count; j++)
                {
                    if (FontStyle == "normal")
                    {
                        if (FontWeight[i] == "100")
                        {
                            FontFileStyle = FontFileStyles[0];
                            var links = Res.Links_100;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "200")
                        {
                            FontFileStyle = FontFileStyles[1];
                            var links = Res.Links_200;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "300")
                        {
                            FontFileStyle = FontFileStyles[2];
                            var links = Res.Links_300;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "400")
                        {
                            FontFileStyle = FontFileStyles[3];
                            var links = Res.Links_regular;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "500")
                        {
                            FontFileStyle = FontFileStyles[4];
                            var links = Res.Links_500;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "600")
                        {
                            FontFileStyle = FontFileStyles[5];
                            var links = Res.Links_600;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "700")
                        {
                            FontFileStyle = FontFileStyles[6];
                            var links = Res.Links_700;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "800")
                        {
                            FontFileStyle = FontFileStyles[7];
                            var links = Res.Links_800;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "900")
                        {
                            FontFileStyle = FontFileStyles[8];
                            var links = Res.Links_900;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                    }
                    else if (FontStyle == "italic")
                    {
                        if (FontWeight[i] == "100")
                        {
                            FontFileStyle = FontFileStyles[0];
                            var links = Res.Links_100italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "200")
                        {
                            FontFileStyle = FontFileStyles[1];
                            var links = Res.Links_200italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "300")
                        {
                            FontFileStyle = FontFileStyles[2];
                            var links = Res.Links_300italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "400")
                        {
                            FontFileStyle = FontFileStyles[3];
                            var links = Res.Links_italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "500")
                        {
                            FontFileStyle = FontFileStyles[4];
                            var links = Res.Links_500italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "600")
                        {
                            FontFileStyle = FontFileStyles[5];
                            var links = Res.Links_600italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "700")
                        {
                            FontFileStyle = FontFileStyles[6];
                            var links = Res.Links_700italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "800")
                        {
                            FontFileStyle = FontFileStyles[7];
                            var links = Res.Links_800italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "900")
                        {
                            FontFileStyle = FontFileStyles[8];
                            var links = Res.Links_900italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                    }
                }
                if (i == SizeAndStyle.CheckedItems.Count)
                {
                    break;
                }
            }
        }


        public void FileDownload(string SelectedFont, string folderName, string FontName, string FontStyle, string FontFileStyle, List<string> links)
        {
            foreach (var link in links)
            {
                if (!string.IsNullOrEmpty(link) && link.Replace("/", " ").Contains(SelectedFont.ToLower().Replace(" ", "")))
                {
                    string[] FontNameInLink = link.ToLower().Split('/');
                    foreach (string fontName in FontNameInLink)
                    {
                        if (fontName == SelectedFont.ToLower().Replace(" ", ""))
                        {
                            WebClient wc = new WebClient();
                            Uri url = new Uri(link);
                            wc.DownloadFileTaskAsync(url,
                                $@"{$"{folderName}\\{FontName.Replace(" ", "")}"}" + $"\\{FontName.Replace(" ", "")}-{FontStyle.Substring(0, 1).ToUpper() + FontStyle.Substring(1)}-{FontFileStyle}.ttf");
                        }
                    }
                }
            }
        }
    }
}
