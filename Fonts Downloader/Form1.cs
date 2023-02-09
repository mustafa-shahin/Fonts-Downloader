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
        private string FolderName, FontName, FontStyle, FontFileStyle;
        private FontsCombox Res = new FontsCombox();
        private new readonly SizeStyles Size = new SizeStyles();
        private List<Item> Items = new List<Item>();
        private List<string> SubSets = new List<string>();
        private CSS css = new CSS();
        private List<string> FontWeight = new List<string>();
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
                css.CreateCSS(SizeAndStyle, SubSets, FolderName, FontName, FontFileStyle);
                FontWeight = css.FontWeight;
                file.FileLinks(SizeAndStyle, FontStyle, FontWeight, FontFileStyle, FontFileStyles, SelectedFont, FolderName, FontName, Res);
            }
        }
    }
}
