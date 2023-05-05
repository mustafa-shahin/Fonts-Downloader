using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class FontFiles
    {

        public void FileLinks(CheckedListBox SizeAndStyle, List<string> FontWeight, Label SelectedFont, string FolderName, FontsCombox ApiResult)
        {
            var Styles = new Dictionary<string, Dictionary<string, List<string>>>
            {
                { "normal", new Dictionary<string, List<string>>
                    {
                        { "100", ApiResult.Links_100 },
                        { "200", ApiResult.Links_200 },
                        { "300", ApiResult.Links_300 },
                        { "400", ApiResult.Links_regular },
                        { "500", ApiResult.Links_500 },
                        { "600", ApiResult.Links_600 },
                        { "700", ApiResult.Links_700 },
                        { "800", ApiResult.Links_800 },
                        { "900", ApiResult.Links_900 },
                    }
                },
                { "italic", new Dictionary<string, List<string>>
                    {
                        { "100", ApiResult.Links_100italic },
                        { "200", ApiResult.Links_200italic },
                        { "300", ApiResult.Links_300italic },
                        { "400", ApiResult.Links_italic },
                        { "500", ApiResult.Links_500italic },
                        { "600", ApiResult.Links_600italic },
                        { "700", ApiResult.Links_700italic },
                        { "800", ApiResult.Links_800italic },
                        { "900", ApiResult.Links_900italic },
                    }
                },
            };
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
            for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
            {
                string FontStyle = SizeAndStyle.CheckedItems[i].ToString().Contains("italic") ? "italic" : "normal";
                for (int j = 0; j < FontWeight.Count; j++)
                {
                    if (Styles[FontStyle].ContainsKey(FontWeight[j]))
                    {
                        FileDownload(SelectedFont.Text, FolderName, FontStyle, FontFileStyles[FontWeight[j]], Styles[FontStyle][FontWeight[j]]);
                    }
                }
            }
        }
        private void FileDownload(string SelectedFont, string folderName, string FontStyle, string FontFileStyle, List<string> links)
        {
            foreach (var link in links)
            {
                if (!string.IsNullOrEmpty(link) && link.Replace("/", " ").Contains(SelectedFont.ToLower().Replace(" ", "")))
                {
                    string[] FontFileLinks = link.ToLower().Split('/');
                    foreach (string fontName in FontFileLinks)
                    {
                        if (fontName == SelectedFont.ToLower().Replace(" ", ""))
                        {
                            var FaileName = $@"{$"{folderName}\\{SelectedFont.Replace(" ", "")}"}" + $"\\{SelectedFont.Replace(" ", "")}-" +
                                $"{FontStyle.Substring(0, 1).ToUpper() + FontStyle.Substring(1)}-{FontFileStyle}.ttf";
                            WebClient wc = new WebClient();
                            Uri url = new Uri(link);
                            if (!File.Exists(FaileName))
                            {
                                wc.DownloadFileTaskAsync(url, FaileName);
                            }
                        }
                    }
                }
            }
        }
    }
}
