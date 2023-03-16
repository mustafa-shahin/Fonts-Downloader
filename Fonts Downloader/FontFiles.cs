using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class FontFiles
    {

        public void FileLinks(CheckedListBox SizeAndStyle, List<string> FontWeight, Label SelectedFont, string FolderName, string FontName, FontsCombox ApiResult)
        {
            string FontStyle="";
            string[] FontFileStyles = { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" };
            string FontFileStyle;
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
                            var links = ApiResult.Links_100;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "200")
                        {
                            FontFileStyle = FontFileStyles[1];
                            var links = ApiResult.Links_200;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "300")
                        {
                            FontFileStyle = FontFileStyles[2];
                            var links = ApiResult.Links_300;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "400")
                        {
                            FontFileStyle = FontFileStyles[3];
                            var links = ApiResult.Links_regular;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "500")
                        {
                            FontFileStyle = FontFileStyles[4];
                            var links = ApiResult.Links_500;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "600")
                        {
                            FontFileStyle = FontFileStyles[5];
                            var links = ApiResult.Links_600;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "700")
                        {
                            FontFileStyle = FontFileStyles[6];
                            var links = ApiResult.Links_700;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "800")
                        {
                            FontFileStyle = FontFileStyles[7];
                            var links = ApiResult.Links_800;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "900")
                        {
                            FontFileStyle = FontFileStyles[8];
                            var links = ApiResult.Links_900;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                    }
                    else if (FontStyle == "italic")
                    {
                        if (FontWeight[i] == "100")
                        {
                            FontFileStyle = FontFileStyles[0];
                            var links = ApiResult.Links_100italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "200")
                        {
                            FontFileStyle = FontFileStyles[1];
                            var links = ApiResult.Links_200italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "300")
                        {
                            FontFileStyle = FontFileStyles[2];
                            var links = ApiResult.Links_300italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "400")
                        {
                            FontFileStyle = FontFileStyles[3];
                            var links = ApiResult.Links_italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "500")
                        {
                            FontFileStyle = FontFileStyles[4];
                            var links = ApiResult.Links_500italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "600")
                        {
                            FontFileStyle = FontFileStyles[5];
                            var links = ApiResult.Links_600italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "700")
                        {
                            FontFileStyle = FontFileStyles[6];
                            var links = ApiResult.Links_700italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "800")
                        {
                            FontFileStyle = FontFileStyles[7];
                            var links = ApiResult.Links_800italic;
                            FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                        }
                        else if (FontWeight[i] == "900")
                        {
                            FontFileStyle = FontFileStyles[8];
                            var links = ApiResult.Links_900italic;
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


        private void FileDownload(string SelectedFont, string folderName, string FontName, string FontStyle, string FontFileStyle, List<string> links)
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
