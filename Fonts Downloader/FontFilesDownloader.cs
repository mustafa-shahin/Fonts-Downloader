using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class FontFilesDownloader
    {

        public void FileLinks(CheckedListBox SizeAndStyle, List<string> FontWeight, Label SelectedFont, string FolderName, FontsCombox ApiResult)
        {
            var Styles = new Dictionary<string, Dictionary<string, List<string>>>
            {
                { "normal", new Dictionary<string, List<string>>
                    {
                        { "100", ApiResult.Links100 },
                        { "200", ApiResult.Links200 },
                        { "300", ApiResult.Links300 },
                        { "400", ApiResult.Links400 },
                        { "500", ApiResult.Links500 },
                        { "600", ApiResult.Links600 },
                        { "700", ApiResult.Links700 },
                        { "800", ApiResult.Links800 },
                        { "900", ApiResult.Links900 },
                    }
                },
                { "italic", new Dictionary<string, List<string>>
                    {
                        { "100", ApiResult.Links100Italic },
                        { "200", ApiResult.Links200Italic },
                        { "300", ApiResult.Links300Italic },
                        { "400", ApiResult.Links400Italic },
                        { "500", ApiResult.Links500Italic },
                        { "600", ApiResult.Links600Italic },
                        { "700", ApiResult.Links700Italic },
                        { "800", ApiResult.Links800Italic },
                        { "900", ApiResult.Links900Italic },
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
            foreach (string checkedItem in SizeAndStyle.CheckedItems)
            {
                string fontStyle = checkedItem.Contains("italic") ? "italic" : "normal";
                foreach (string fontWeight in FontWeight)
                {
                    if (Styles[fontStyle].ContainsKey(fontWeight))
                    {
                        FileDownload(SelectedFont.Text, FolderName, fontStyle, FontFileStyles[fontWeight], Styles[fontStyle][fontWeight]);
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
