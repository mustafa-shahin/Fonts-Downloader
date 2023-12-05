using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    public partial class MainForm : Form
    {
        private List<Item> Items;
        private string FolderName;
        private string SelectedFont;
        private Point Offset;
        private Item SelectedFontItem;
        private readonly WebFonts Fonts = new();
        private readonly HtmlFile Html = new();

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            //_ = InitAsync(Path.Combine(WebViewEnvironmentFolder, "WebView Environment"));
            webView21.EnsureCoreWebView2Async();
            webView21.BackColor = Color.FromArgb(32, 33, 36);
            webView21.Source = new Uri("file:///C:/FontDownloader/index.html");
            HtmlFile.DefaultHtml();
            if (!Api.IsInternetAvailable() || !Api.IsNetworkAvailable())
                NoInternet.Visible = true;
            TTF.Visible = false;
            WOFF2.Visible = false;
            FontBox1.Enabled = false;
            Minify.Visible = false;
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
            var PreviousFont = string.Empty;
            SelectedFont = FontBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(SelectedFont) && !(SelectedFont == PreviousFont && SubsetsLists.Items.Count > 0))
            {
                if (!string.IsNullOrEmpty(PreviousFont) && PreviousFont != SelectedFont)
                {
                    SubsetsLists.Items.Clear();
                    SizeAndStyle.Items.Clear();
                    Minify.Visible = true;
                }
                SelectedFontLabel.Text = SelectedFont;
                if (Items is not null && Items.Any())
                    SelectedFontItem = Items.FirstOrDefault(m => m.Family == SelectedFontLabel.Text);
                SubsetsLists.Items.AddRange(SelectedFontItem.Subsets.Select(m => char.ToUpper(m[0]) + m[1..]).ToArray());
                var FontWeights = new SizeStyles();
                var Variants = FontWeights.LoadSizeStyles(SelectedFontItem);
                SizeAndStyle.Items.AddRange(Variants.ToArray());
                Html.CreateHtml(SelectedFont, Variants);
            }
            PreviousFont = SelectedFont;
            webView21.CoreWebView2.Navigate("file:///C:/FontDownloader/index.html");
        }
        private async void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ApiKeyBox.Text))
            {
                Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, false);
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
                        WOFF2.Visible = true;
                        TTF.Visible = true;
                        FontBox1.Enabled = true;
                        Minify.Visible = true;
                    }
                    else
                    {
                        webView21.Reload();
                        WOFF2.Visible = false;
                        TTF.Visible = false;
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
        private void MianForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            var RootPath = @"C:/FontDownloader";
            if (Directory.Exists(RootPath))
            {
                var HtmlPath = @$"{RootPath}/index.html";
                if (File.Exists(HtmlPath))
                {
                    File.Delete(HtmlPath);
                }
                Directory.Delete(RootPath);
            }
        }
        private async void CopyFont_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(FolderName))
            {
                var Variants = SizeAndStyle.CheckedItems.Cast<string>().ToList();
                var minify = Minify.Checked;
                if (Variants != null && Variants.Any())
                {
                    var Css = new CssFile();
                    var Subsets = SubsetsLists.CheckedItems.Cast<string>().ToList();

                    if (SubsetsLists.CheckedItems.Count > 0)
                        Css.CreateCSS(Variants, FolderName, SelectedFont, WOFF2.Checked, false, Subsets);
                    else if (Minify.Checked)
                        Css.CreateCSS(Variants, FolderName, SelectedFont, WOFF2.Checked, minify);
                    else
                        Css.CreateCSS(Variants, FolderName, SelectedFont, WOFF2.Checked);

                    SelectedFontItem.Variants = Variants;
                    var Downloader = new FontFilesDownloader();
                    Task FileToDownload = Downloader.Download(SelectedFontItem, FolderName, WOFF2.Checked);
                    await FileToDownload;
                    if (FileToDownload.Status == TaskStatus.RanToCompletion)
                    {
                        DialogResult dialogResult = MessageBox.Show("The Download has been completed. Do you want to check downloaded files? ", "Download completed", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            try
                            {
                                var FolderToOpen = Path.Combine(FolderName, SelectedFont.Replace(" ", ""));
                                Process.Start("explorer.exe", FolderToOpen);
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
        private static void ShowGitRepo(object sender, EventArgs e)
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
        private void Close_Click(object sender, EventArgs e) => Application.Exit();

        private void Minimize_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

        private void Header_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Offset = new Point(e.X, e.Y);
        }
        private void Header_MouseUp(object sender, MouseEventArgs e) => Offset = Point.Empty;
        private void Minify_CheckedChanged(object sender, EventArgs e)
        {
            if (Minify.Checked)
            {
                MessageBox.Show("All comments will be deleted in minified version");
                SubsetsLists.ClearSelected();
            }              
            SubsetsLists.Enabled = !Minify.Checked;
        }
        private new void MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Location = new Point(Location.X + e.X - Offset.X, Location.Y + e.Y - Offset.Y);
        }
        private async void WOFF2_Checked(object sender, EventArgs e) => await HandleFontTypeChecked(WOFF2, TTF);
        private async void TTF_Checked(object sender, EventArgs e) => await HandleFontTypeChecked(TTF, WOFF2);
        private async Task HandleFontTypeChecked(CheckBox checkedBox, CheckBox otherBox)
        {
            if (checkedBox.Checked)
            {
                otherBox.Checked = !checkedBox.Checked;
                Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, checkedBox == WOFF2);
                SelectedFontItem = Items.FirstOrDefault(m => m.Family == SelectedFontLabel.Text);
            }
        }
        private void SubsetsLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SubsetsLists.CheckedItems.Count > 0)
                Minify.Enabled = false;
            else
                Minify.Enabled = true;
        }
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        var currentScreen = Screen.FromControl(this);
        //        Location = currentScreen.WorkingArea.Location;
        //        MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        //        WindowState = FormWindowState.Maximized;
        //    }
        //    else if (WindowState == FormWindowState.Maximized)
        //        WindowState = FormWindowState.Normal;
        //}

        //private async Task InitAsync(string path)
        //{
        //    var env = await CoreWebView2Environment.CreateAsync(userDataFolder: path);
        //    await webView21.EnsureCoreWebView2Async(env);
        //}
        //private void WebView21_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        //{
        //    if (webView21 != null && webView21.CoreWebView2 != null)
        //    {
        //        webView21.CoreWebView2.Navigate("file:///C:/FontDownloader/index.html");
        //    }
        //}
    }
}