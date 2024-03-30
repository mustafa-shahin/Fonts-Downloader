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
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public partial class MainForm : Form
    {
        private List<Item> Items;
        private string FolderName;
        private string SelectedFontFamily;
        private Point Offset;
        private Item SelectedFontItem;
        private readonly WebFonts Fonts = new();
        private string PreviousFont = string.Empty;

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            //_ = InitAsync(Path.Combine(WebViewEnvironmentFolder, "WebView Environment"));
            webView21.EnsureCoreWebView2Async();
            webView21.BackColor = Color.FromArgb(32, 33, 36);
            webView21.Source = new Uri("file:///C:/FontDownloader/index.html");
            if (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
            {                                         
                HtmlFile.DefaultHtml();
                //if (!Helper.IsInternetAvailable() || !Helper.IsNetworkAvailable())
                //    NoInternet.Visible = true;
                TTF.Visible = false;
                WOFF2.Visible = false;
                FontBox1.Enabled = false;
                Minify.Visible = false;
#if DEBUG

                string keyPath = "C:/Users/musta/Desktop/key.txt";
                if (File.Exists(keyPath))
                {
                    ApiKeyBox.Text = File.ReadAllText(keyPath);
                }
                FolderName = "C:\\Users\\musta\\Desktop\\GoogleFonts";
                SelectedFolder.Text = FolderName;
#endif
            }
            else
                NoInternetAvailable();

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
            SelectedFontFamily = FontBox1.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(SelectedFontFamily) && SelectedFontFamily != PreviousFont)
            {
                if (!string.IsNullOrEmpty(PreviousFont))
                {
                    SubsetsLists.Items.Clear();
                    SizeAndStyle.Items.Clear();
                    Minify.Visible = true;
                }
                SelectedFontLabel.Text = SelectedFontFamily;
                if (Items is not null && Items.Any())
                    SelectedFontItem = Items.FirstOrDefault(m => m.Family == SelectedFontLabel.Text);

                SubsetsLists.Items.AddRange(SelectedFontItem.Subsets.Select(m => char.ToUpper(m[0]) + m[1..]).ToArray());

                if (SelectedFontItem.Variants is not null && SelectedFontItem.Variants.Any())
                {
                    SizeAndStyle.Items.AddRange(SelectedFontItem.Variants.Select(Helper.MapVariant)
                                                            .OrderBy(variant => variant.EndsWith("italic"))
                                                            .ThenBy(variant => variant)
                                                            .Select(variant => variant.Replace("italic", " italic"))
                                                            .ToArray());
                    HtmlFile.CreateHtml(SelectedFontItem);
                }
                PreviousFont = SelectedFontFamily;
                webView21.CoreWebView2.Navigate("file:///C:/FontDownloader/index.html");

                if(Minify.Enabled == false)
                    Minify.Enabled = true;
            }
        }
        private async void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(ApiKeyBox.Text))
            {
                if (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
                {
                    if (NoInternet.Visible)
                    {
                        NoInternet.Visible = false;
                        HtmlFile.DefaultHtml();
                        webView21.Reload();
                    }
                    try
                    {
                        Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, false);
                        if (Api.Succeeded)
                        {
                            if (Items != null && Items.Any())
                            {
                                FontBox1.Items.AddRange(Items.Select(item => item.Family).ToArray());
                                WOFF2.Visible = true;
                                TTF.Visible = true;
                                TTF.Checked = true;
                                FontBox1.Enabled = true;
                                Minify.Visible = true;
                                if(Fonts.Error is not null)
                                {
                                    HtmlFile.DefaultHtml();
                                    webView21.Reload();
                                    Fonts.Error = null;
                                }
                                
                            }
                        }
                        else
                        {
                            HtmlFile.DefaultHtml(Fonts.Error);
                            webView21.Reload();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("your api key is not correct " + ex.Message);
                    }
                }
                else
                    NoInternetAvailable();
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
            if (!(Helper.IsInternetAvailable() || Helper.IsNetworkAvailable()))
            {
                NoInternetAvailable();
                return;
            }
            if (string.IsNullOrWhiteSpace(FolderName))
            {
                MessageBox.Show("Please select a folder");
                return;
            }
            if (SizeAndStyle.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose a variant");
                return;
            }
            if (SelectedFontItem is not null && SelectedFontItem.Variants is not null && SelectedFontItem.Variants.Any())
            {
                var selectedFont = SelectedFontItem;
                selectedFont.Variants = SizeAndStyle.CheckedItems.Cast<string>().Where(m => !string.IsNullOrEmpty(m)).ToList();
                if (selectedFont.Variants is not null && selectedFont.Variants.Any())
                {
                    var css = new CssFile();
                    var subsets = SubsetsLists.CheckedItems.Cast<string>().ToArray();

                    css.CreateCSS(selectedFont, FolderName, WOFF2.Checked, Minify.Checked, subsets);
                    try
                    {
                        using (var downloader = new FontFilesDownloader())
                        {
                            await downloader.DownloadAsync(selectedFont, FolderName, WOFF2.Checked);
                        }
                        OpenDownloadFolder(FolderName, selectedFont.Family.Replace(" ", ""));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Download failed: {ex.Message}");
                    }
                }
            }
        }
        private static void OpenDownloadFolder(string folderName, string fontFolderName)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("The Download has been completed. Do you want to check downloaded files? ", "Download completed", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var folderToOpen = Path.Combine(folderName, fontFolderName);
                    Process.Start("explorer.exe", folderToOpen);
                }                
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Error opening folder: {ex.Message}");
            }
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
            if (Helper.IsNetworkAvailable() || Helper.IsInternetAvailable())
            {
                if (checkedBox.Checked)
                {
                    otherBox.Checked = !checkedBox.Checked;
                    Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, checkedBox == WOFF2);
                    SelectedFontItem = Items.FirstOrDefault(m => m.Family == SelectedFontLabel.Text);
                }
            }
            else
                NoInternetAvailable();
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
        private void NoInternetAvailable()
        {
            NoInternet.Visible = true;
            HtmlFile.DefaultHtml();
            MessageBox.Show("Check your internet connection");
        }

        private void NoInternet_Click(object sender, EventArgs e)
        {
            if (Helper.IsInternetAvailable() || Helper.IsNetworkAvailable())
            {
                if (SelectedFontItem is not null)
                    HtmlFile.CreateHtml(SelectedFontItem);
                else
                    HtmlFile.DefaultHtml();

                NoInternet.Visible = false;
            }
            else
                HtmlFile.DefaultHtml(Fonts.Error);

            webView21.Reload();
        }
    }
}