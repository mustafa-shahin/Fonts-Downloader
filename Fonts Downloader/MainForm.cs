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
        private Point Offset;
        private Item SelectedFontItem;
        private readonly WebFonts Fonts = new();
        private static readonly string HtmlPath = AppDomain.CurrentDomain.BaseDirectory + "/FontsWebView.html";
        private Error Error;
        private HtmlFile Html = new();
        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;
            //_ = InitAsync(Path.Combine(WebViewEnvironmentFolder, "WebView Environment"));
            webView.EnsureCoreWebView2Async();
            webView.BackColor = Color.FromArgb(32, 33, 36);
            if (File.Exists(HtmlPath))
            {
                try
                {
                    string fileContent = File.ReadAllText(HtmlPath);
                    if (!string.IsNullOrEmpty(fileContent))
                    {
                        File.WriteAllText(HtmlPath, string.Empty);
                    }
                }
                catch (Exception ex)
                {
                    Logger.HandleError("An error occurred: ", ex);
                }
            }
            Html.DefaultHtml(Helper.IsNetworkAvailable());
            webView.Source = new Uri(HtmlPath);
            if (Helper.IsNetworkAvailable())
            {
                TTF.Visible = false;
                WOFF2.Visible = false;
                FontBox1.Enabled = false;
                Minify.Visible = false;
#if DEBUG
                string apiKey = Helper.GetAPIKey();
                if (!string.IsNullOrEmpty(apiKey))
                {
                    ApiKeyBox.Text = apiKey;
                }
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                FolderName = Path.Combine(desktopPath, "GoogleFonts");
#endif
                SelectedFolder.Text = FolderName;
            }
            else
            {
                webView.Reload();
                NoInternet.Visible = true;
            }
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
            string selectedFontFamily = FontBox1.SelectedItem?.ToString();
            var fontSelector = new FontSelector();
            SelectedFontItem = fontSelector?.FontSelection(selectedFontFamily, Items, UpdateUIComponents);

        }
        private void UpdateUIComponents(string selectedFontLabel, IEnumerable<string> subsets, IEnumerable<string> variants)
        {
            SubsetsLists.Items.Clear();
            SizeAndStyle.Items.Clear();
            SelectedFontLabel.Text = selectedFontLabel;
            SubsetsLists.Items.AddRange(subsets.ToArray());
            SizeAndStyle.Items.AddRange(variants.ToArray());
            webView.CoreWebView2.Navigate(HtmlPath);
            Minify.Visible = true;
            Minify.Enabled = true;


        }
        private async void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ApiKeyBox.Text)) return;

            if (!Helper.IsNetworkAvailable())
            {
                webView.Reload();
                NoInternet.Visible = true;
                return;
            }

            try
            {
                Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, false);

                if (Items != null && Items.Count != 0)
                {
                    FontBox1.Items.AddRange(Items.Select(item => item.Family).ToArray());
                    WOFF2.Visible = true;
                    TTF.Visible = true;
                    TTF.Checked = true;
                    FontBox1.Enabled = true;
                    Minify.Visible = true;
                    if (Error == null)
                        webView.Reload();
                }
                else if (Fonts.FontResponse?.Error != null)
                {
                    MessageBox.Show($"API Error: {Fonts.FontResponse.Error.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Error = Fonts.FontResponse.Error;
                    await Task.Run(() => Html.DefaultHtml(false, Fonts));
                    webView.Reload();
                    NoInternet.Visible = true;
                    Error = null;
                }
            }
            catch (Exception ex)
            {
                Logger.HandleError("An error occurred while processing your request.", ex);
                MessageBox.Show("An error occurred while processing your request. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async void CopyFont_Click(object sender, EventArgs e)
        {
            if (!Helper.IsNetworkAvailable())
            {
                webView.Reload();
                NoInternet.Visible = true;
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

            if (SelectedFontItem is null || SelectedFontItem.Variants is null || SelectedFontItem.Variants.Count == 0)
            {
                Logger.HandleError("Selected font item or its variants are null or empty.", new Exception("Invalid font selection."));
                return;
            }

            var selectedFont = SelectedFontItem;
            selectedFont.Variants = SizeAndStyle.CheckedItems.Cast<string>().Where(m => !string.IsNullOrEmpty(m)).ToList();
            var css = new CssFile();
            var subsets = SubsetsLists.CheckedItems.Cast<string>().ToArray();

            try
            {
                await Task.Run(() => css.CreateCSS(selectedFont, FolderName, WOFF2.Checked, Minify.Checked, subsets));
                using (var downloader = new FontFilesDownloader())
                {
                    await downloader.DownloadAsync(selectedFont, FolderName, WOFF2.Checked);
                }
                OpenDownloadFolder(FolderName, selectedFont.Family.Replace(" ", ""));
            }
            catch (Exception ex)
            {
                Logger.HandleError("Download failed", ex);
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
                Logger.HandleError("Error opening folder", ex);
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
        private async Task HandleFontTypeChecked(CheckBox checkedBox, CheckBox otherBox)
        {
            if (Helper.IsNetworkAvailable())
            {
                if (checkedBox.Checked)
                {
                    otherBox.Checked = !checkedBox.Checked;
                    Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, checkedBox == WOFF2);
                }
            }
            else
            {
                webView.Reload();
                NoInternet.Visible = false;
            }

        }
        private async void WOFF2_Click(object sender, EventArgs e) => await HandleFontTypeChecked(WOFF2, TTF);
        private async void TTF_Click(object sender, EventArgs e) => await HandleFontTypeChecked(TTF, WOFF2);


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
        //    await webView.EnsureCoreWebView2Async(env);
        //}
        //private void webView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        //{
        //    if (webView != null && webView.CoreWebView2 != null)
        //    {
        //        webView.CoreWebView2.Navigate("file:///C:/FontDownloader/FontsWebView.html");
        //    }
        //}
        private void NoInternet_Click(object sender, EventArgs e)
        {
            if (Helper.IsNetworkAvailable())
            {
                if (SelectedFontItem is not null)
                    Html.CreateHtml(SelectedFontItem);
                else
                    Html.DefaultHtml();

                NoInternet.Visible = false;
            }
            else
                Html.DefaultHtml(false, Fonts);

            webView.Reload();
        }
        private void WebView_NavigationStarting(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            try
            {
                if (!e.Uri.Contains("FontsWebView.html"))
                {
                    e.Cancel = true;
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = e.Uri,
                        UseShellExecute = true
                    });
                }
            }
            catch (Exception ex)
            {
                // Log or handle any exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}