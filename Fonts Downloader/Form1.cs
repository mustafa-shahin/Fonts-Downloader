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
        private string FolderName, FontStyle, FontFileStyle;
        private FontsCombox Res = new FontsCombox();
        private new readonly SizeStyles Size = new SizeStyles();
        private List<Item> Items = new List<Item>();
        private List<string> SubSets = new List<string>();
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
            string[] FontFileStyles = { "Thin", "ExtraLight", "Light", "Regular", "Medium", "SemiBold", "Bold", "ExtraBold", "Black" };
            var FontWeight = new List<string>();
            var css = new CSS();
            var File = new FontFiles();
            if (FontBox1.SelectedItem != null)
            {
                string FontName = SelectedFont.Text;
                Directory.CreateDirectory($"{FolderName}\\{FontName.Replace(" ", "")}");
                DirectoryInfo di = new DirectoryInfo($"{FolderName}\\{FontName.Replace(" ", "")}");
                foreach (FileInfo file in di.EnumerateFiles())
                {
                    if (file.Name.Contains(".ttf") || file.Name.Contains(".html"))
                    {
                        file.Delete();
                    }
                }
                css.CreateCSS(SizeAndStyle, SubSets, FolderName, FontName, FontFileStyle);
                css.CreateHtml(SizeAndStyle, FolderName, FontName);
                FontWeight = css.FontWeight;
                File.FileLinks(SizeAndStyle, FontStyle, FontWeight, FontFileStyle, FontFileStyles, SelectedFont, FolderName, FontName, Res);
            }
        }
    }
}