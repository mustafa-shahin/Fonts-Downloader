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
    public partial class MainForm : Form
    {
        private string PreviousFont = string.Empty;
        private List<Item> Items;
        private string FolderName;
        private string SelectedFonts;
        private string Key = "";
        private readonly SizeStyles SizeStyles = new();
        private readonly string WebViewEnvironmentFolder = @"C:/FontDownloader/";

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            _ = InitAsync(Path.Combine(WebViewEnvironmentFolder, "WebView Environment"));
            //webView21.EnsureCoreWebView2Async();         
            webView21.BackColor = Color.FromArgb(45, 62, 79);
            webView21.Source = new Uri("file:///C:/FontDownloader/index.html");
            HtmlFile.DefaultHtml();
            TTF.Enabled = false;
            WOFF2.Enabled = false;
            FontBox1.Enabled = false;
            Minify.Enabled = false;

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

        private async void WOFF2_CheckedChanged(object sender, EventArgs e)
        {
            if (WOFF2.Checked)
            {
                TTF.Checked = !WOFF2.Checked;
                Items = await FontsComboBox.GetWebFontsAsync(Key, WOFF2.Checked);
            }

        }

        private async void TTF_CheckedChanged(object sender, EventArgs e)
        {
            if (TTF.Checked)
            {
                WOFF2.Checked = !TTF.Checked;
                Items = await FontsComboBox.GetWebFontsAsync(Key, WOFF2.Checked);
            }

        }
        private void FontBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SelectedFonts = FontBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(SelectedFonts) && !(SelectedFonts == PreviousFont && SubsetsLists.Items.Count > 0))
            {
                if (!string.IsNullOrEmpty(PreviousFont) && PreviousFont != SelectedFonts)
                {
                    SubsetsLists.Items.Clear();
                    SizeAndStyle.Items.Clear();
                    Minify.Enabled = true;
                }
                SelectedFont.Text = SelectedFonts;
                SubsetsLists.Items.AddRange(Items
                  .Where(item => item.Family == SelectedFonts)
                  .SelectMany(item => item.Subsets)
                  .Select(item => char.ToUpper(item[0]) + item[1..]).ToArray());

                var Variants = SizeStyles.LoadSizeStyles(Items, SelectedFonts);
                SizeAndStyle.Items.AddRange(Variants.ToArray());
                HtmlFile.CreateHtml(SelectedFonts, Variants);
            }
            PreviousFont = SelectedFonts;
            webView21.CoreWebView2.Navigate("file:///C:/FontDownloader/index.html");

        }
        private async void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ApiKeyBox.Text))
            {
                Key = ApiKeyBox.Text;
                Items = await FontsComboBox.GetWebFontsAsync(Key, true);
                try
                {
                    if (Api.Succeeded)
                    {
                        if (Items != null && Items.Any())
                        {
                            foreach (var item in Items)
                            {
                                FontBox1.Items.Add(item.Family);
                            }
                        }
                        WOFF2.Enabled = true;
                        TTF.Enabled = true;
                        FontBox1.Enabled = true;
                        Minify.Enabled = true;
                        ApiKeyBox.Enabled = false;
                    }
                    else
                    {
                        webView21.Reload();
                        WOFF2.Enabled = false;
                        TTF.Enabled = false;
                        FontBox1.Enabled = false;
                        Minify.Enabled = false;
                        FontBox1.Items.Clear();
                        SizeAndStyle.Items.Clear();
                        SubsetsLists.Items.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("your api key is not correct " + ex.Message);
                }
            }

        }
        //private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    if (Directory.Exists(@"C:/FontDownloader"))
        //    {
        //        if (System.IO.File.Exists(@"C:/FontDownloader/index.html"))
        //        {
        //            System.IO.File.Delete(@"C:/FontDownloader/index.html");
        //        }
        //        Directory.Delete(@"C:/FontDownloader");
        //    }
        //}

        //private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        //{
        //    ensure = true;
        //}

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
                    var Subsets = SubsetsLists.CheckedItems.Cast<string>().ToList();
                    if (SubsetsLists.CheckedItems.Count > 0)
                        css.CreateCSS(Variants, FolderName, SelectedFonts, WOFF2.Checked, false, Subsets);
                    else
                        css.CreateCSS(Variants, FolderName, SelectedFonts, WOFF2.Checked, minify);
                    Task FileToDownload = File.Download(Items, SelectedFonts, FolderName, Variants, WOFF2.Checked);
                    await FileToDownload;
                    if (FileToDownload.Status == TaskStatus.RanToCompletion)
                    {
                        DialogResult dialogResult = MessageBox.Show("The Download has been completed. Do you want to check downloaded files? ", "Download completed", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                var FolderToOpen = Path.Combine(FolderName, SelectedFonts.Replace(" ", ""));
                                Process.Start("explorer.exe", FolderToOpen); ;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error opening folder: {ex.Message}");
                            }

                        }
                    }
                    else if (FileToDownload.IsFaulted)
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

        private void Minify_CheckedChanged(object sender, EventArgs e)
        {
            if (Minify.Checked)
                SubsetsLists.Enabled = false;
            else
                SubsetsLists.Enabled = true;
        }
        private async Task InitAsync(string path)
        {
            var env = await CoreWebView2Environment.CreateAsync(userDataFolder: path);
            await webView21.EnsureCoreWebView2Async(env);
        }
        private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            if (webView21 != null && webView21.CoreWebView2 != null)
            {
                webView21.CoreWebView2.Navigate("file:///C:/FontDownloader/index.html");
            }
        }

        private void SubsetsLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubsetsLists.CheckedItems.Count > 0)
                Minify.Enabled = false;
            else
                Minify.Enabled = true;
        }
        private static void ShowGitRepo()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/mustafa-shahin/Fonts-Downloader",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void GitHubLink_Click(object sender, EventArgs e)
        {
            ShowGitRepo();
        }

        private void GitPic_Click(object sender, EventArgs e)
        {
            ShowGitRepo();
        }
    }
}