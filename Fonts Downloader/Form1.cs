using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Fonts_Downloader
{
    public partial class Form1 : Form
    {
        private string[] FontFileStyles = { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" };
        private string FontFileStyle;
        private string FolderName, FontName;
        private FontsCombox Res = new FontsCombox();
        private new readonly SizeStyles Size = new SizeStyles();
        private List<Item> Items = new List<Item>();
        private List<string> SubSets = new List<string>();
        private CSS css = new CSS();
        private List<string> FontWeight = new List<string>();
        private string FontStyle;
        FontFiles file = new FontFiles();
        public Form1()
        {           
            InitializeComponent();
            _ = Res.resAsync(FontBox1);         
            SubSets = Size.SubsetList;
            Items = Res.AllList;           
        }
        private void SelectFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderName = folderBrowserDialog.SelectedPath;
            }
            textBox1.Text = FolderName;
        }


        private void FontBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {           
            Size.SizeStylesLoad(FontBox1, SelectedFont, SizeAndStyle, Items);
        }
        private void CopyFont_Click(object sender, EventArgs e)
        {
            
            if (FontBox1.SelectedItem != null)
            {
                List<string> links = new List<string>();
                FontName = FontBox1.SelectedItem.ToString();
                Directory.CreateDirectory($"{FolderName}\\{FontName.Replace(" ", "")}");
                DirectoryInfo di = new DirectoryInfo($"{FolderName}\\{FontName.Replace(" ", "")}");
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    if (file.Name.Contains(".ttf"))
                    {
                        file.Delete();
                    }
                }
                css.CreateCSS(SizeAndStyle, SubSets, FolderName, FontName,FontFileStyle);
                FontWeight = css.__FontWeight;
                file.FileLinks(SizeAndStyle, FontStyle, FontWeight, FontFileStyle, FontFileStyles, SelectedFont, FolderName, FontName, Res);
                //for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
                //{
                //    if (!SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                //    {
                //        FontStyle = "normal";
                //    }
                //    else if (SizeAndStyle.CheckedItems[i].ToString().Contains("italic"))
                //    {
                //        FontStyle = "italic";
                //    }
                //    for (int j = 0; j <= FontWeight.Count; j++)
                //    {
                //        if (FontStyle == "normal")
                //        {
                //            if (FontWeight[i] == "100")
                //            {
                //                FontFileStyle = FontFileStyles[0];
                //                links = Res.Links_100;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "200")
                //            {
                //                FontFileStyle = FontFileStyles[1];
                //                links = Res.Links_200;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "300")
                //            {
                //                FontFileStyle = FontFileStyles[2];
                //                links = Res.Links_300;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "400")
                //            {
                //                FontFileStyle = FontFileStyles[3];
                //                links = Res.Links_regular;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "500")
                //            {
                //                FontFileStyle = FontFileStyles[4];
                //                links = Res.Links_500;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "600")
                //            {
                //                FontFileStyle = FontFileStyles[5];
                //                links = Res.Links_600;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "700")
                //            {
                //                FontFileStyle = FontFileStyles[6];
                //                links = Res.Links_700;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "800")
                //            {
                //                FontFileStyle = FontFileStyles[7];
                //                links = Res.Links_800;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "900")
                //            {
                //                FontFileStyle = FontFileStyles[8];
                //                links = Res.Links_900;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //        }
                //        if (FontStyle == "italic")
                //        {
                //            if (FontWeight[i] == "100")
                //            {
                //                FontFileStyle = FontFileStyles[0];
                //                links = Res.Links_100italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "200")
                //            {
                //                FontFileStyle = FontFileStyles[1];
                //                links = Res.Links_200italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "300")
                //            {
                //                FontFileStyle = FontFileStyles[2];
                //                links = Res.Links_300italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "400")
                //            {
                //                FontFileStyle = FontFileStyles[3];
                //                links = Res.Links_italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "500")
                //            {
                //                FontFileStyle = FontFileStyles[4];
                //                links = Res.Links_500italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "600")
                //            {
                //                FontFileStyle = FontFileStyles[5];
                //                links = Res.Links_600italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "700")
                //            {
                //                FontFileStyle = FontFileStyles[6];
                //                links = Res.Links_700italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "800")
                //            {
                //                FontFileStyle = FontFileStyles[7];
                //                links = Res.Links_800italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //            if (FontWeight[i] == "900")
                //            {
                //                FontFileStyle = FontFileStyles[8];
                //                links = Res.Links_900italic;
                //                file.FileDownload(SelectedFont.Text, FolderName, FontName, FontStyle, FontFileStyle, links);
                //            }
                //        }
                //    }
                //    if (i == SizeAndStyle.CheckedItems.Count)
                //    {
                //        break;
                //    }
                //}
            }
        }
    }
}
