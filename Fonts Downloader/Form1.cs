using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public partial class Form1 : Form
    {
        private string previousFont = string.Empty;
        private List<Item> Items;

        private string FolderName;
        private readonly HtmlFile Document = new HtmlFile();
        private string SelectedFonts;
        private bool ensure = false;
        private string Key = " ";
        private List<string> Subsets;
        public Form1()
        {
            InitializeComponent();
            webView21.EnsureCoreWebView2Async();
            Document.DefaultHtml();
            webView21.BackColor = Color.FromArgb(45, 62, 79);
            webView21.Source = new Uri("file:///C:/FontDownlaoder/index.html");
        }

        private void SelectFolder_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FolderName = folderBrowserDialog.SelectedPath;
                }
            }
            SelectedFolder.Text = FolderName;
        }

        private void FontBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectedFonts = FontBox1.SelectedItem?.ToString();
            SelectedFont.Text = SelectedFonts;
            Subsets = Items
              .Where(item => item.Family == SelectedFonts)
              .SelectMany(item => item.Subsets)
              .Select(item => char.ToUpper(item[0]) + item.Substring(1))
               .ToList();

            if (SelectedFonts != previousFont)
            {
                SubsetsLists.Items.Clear();
                SizeAndStyle.Items.Clear();
                previousFont = SelectedFonts;
            }

            var sizeStyles = new SizeStyles();
            var Variants = sizeStyles.LoadSizeStyles(Items, SelectedFonts);

            foreach (var subset in Subsets)
            {
                SubsetsLists.Items.Add(subset);
            }
            SizeAndStyle.Items.AddRange(Variants.ToArray());
            Document.CreateHtml(SelectedFonts, Variants);

            if (ensure)
            {
                webView21.CoreWebView2.Navigate("file:///C:/FontDownlaoder/index.html");
            }
        }

        private async void TextBox2_TextChanged(object sender, EventArgs e)
        {
            Key = ApiKeyBox.Text;
            if (!string.IsNullOrEmpty(Key))
            {
                var Fonts = new FontsComboBoxx();
                Items = await Fonts.ResAsync(Key);
                foreach (var item in Items)
                {
                    FontBox1.Items.Add(item.Family);
                }
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

        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            ensure = true;
        }

        private async void CopyFont_Click(object sender, EventArgs e)
        {
            var css = new CssFile();
            if (!string.IsNullOrEmpty(FolderName))
            {
                var Variants = SizeAndStyle.CheckedItems.Cast<string>().ToList();
                var File = new FontFilesDownloader();
                var minify = Minify.Checked;
                if (Variants != null && Variants.Any())
                {
                    if (SubsetsLists.CheckedItems.Count > 0)
                        css.CreateCSS(Variants, FolderName, SelectedFonts, minify, Subsets);
                    else
                        css.CreateCSS(Variants, FolderName, SelectedFonts, minify);
                    Task fileLinksTask = File.FileLinks(Items, SelectedFonts, FolderName, Variants);
                    await fileLinksTask;
                    if (fileLinksTask.Status == TaskStatus.RanToCompletion)
                    {
                        DialogResult dialogResult = MessageBox.Show("The Downlaod has been completed. Do you want to check downloaded files? ", "Download completed", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Process.Start($"{FolderName}\\{SelectedFonts.Replace(" ", "")}");
                        }
                    }
                    else if (fileLinksTask.IsFaulted)
                    {
                        MessageBox.Show("Download failed ");
                    }
                }
                else
                    MessageBox.Show("Please choose a variant ");
            }
            else
                MessageBox.Show("Please select a folder");
        }
    }
}