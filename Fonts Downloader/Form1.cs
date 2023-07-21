using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public partial class Form1 : Form
    {
        private string FolderName;
        private FontsCombox ApiResult = new FontsCombox();
        private new readonly SizeStyles Size = new SizeStyles();
        private HtmlFile Document = new HtmlFile();
        private List<Item> Items = new List<Item>();
        private List<string> SubSets = new List<string>();
        private bool ensure = false;
        private string Key=" ";

        public Form1()
        { 
            InitializeComponent();
            webView21.EnsureCoreWebView2Async();
            Document.DefaultHtml();
            SubSets = Size.SubsetList;
            Items = ApiResult.AllList;           
            webView21.BackColor = Color.FromArgb(45, 62, 79);
            webView21.Source = new Uri("file:///C:/FontDownlaoder/index.html");
        }
       
        private void SelectFolder_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderName = folderBrowserDialog.SelectedPath;
            }
            SelectedFolder.Text = FolderName;
        }

        private void FontBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Key = ApiKeyBox.Text;
            
            Size.SizeStylesLoad(FontBox1, SelectedFont, SizeAndStyle, Items);
            Document.CreateHtml(SelectedFont, SizeAndStyle);
            //string path = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            //string NewPath = Path.Combine(path, "html", "index.html");
            //string text = System.IO.File.ReadAllText(NewPath);           
            if (ensure)
                webView21.CoreWebView2.Navigate("file:///C:/FontDownlaoder/index.html");
          
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Key = ApiKeyBox.Text;
            if (!string.IsNullOrEmpty(Key))
            {
                _ = ApiResult.resAsync(FontBox1, Key);
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(@"C:/FontDownlaoder"))
            {
                if (System.IO.File.Exists(@"C:/FontDownlaoder/index.html"))
                {
                    System.IO.File.Delete(@"C:/FontDownlaoder/index.html");
                }
                Directory.Delete(@"C:/FontDownlaoder");
            }
        }

        private void CopyFont_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FolderName))
            {
                var FontWeight = new List<string>();
                var css = new CssFile();
                var File = new FontFilesDownloader();
                if (FontBox1.SelectedItem != null)
                {
                    string FontName = SelectedFont.Text;
                    css.CreateCSS(SizeAndStyle, SubSets, FolderName, FontName);
                    FontWeight = css.FontWeight;
                    if (FontWeight.Any())
                    {                      
                        File.FileLinks(SizeAndStyle, FontWeight, SelectedFont, FolderName, ApiResult);
                        DialogResult dialogResult = MessageBox.Show("The Downlaod has been completed. Do you want to check downloaded files? ", "Download completed", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start($"{FolderName}\\{FontName.Replace(" ", "")}");
                        }
                    }                      
                    else
                        MessageBox.Show("Please choose a font weight");                 
                }
            }
            else
            {
                MessageBox.Show("Please select a folder ");
            }
        }
        private void webView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            ensure = true;  
        }
    }
}