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
        private static readonly string HtmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FontsWebView.html");
        private HtmlBuilder Html = new();
        private bool isInitialized = false;

        public MainForm()
        {
            InitializeComponent();
            SetupForm();
            InitializeWebView();
            CheckInternetConnection();
            LoadApiKey();
        }

        private void SetupForm()
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            // Link GitHub button
            GitHubLink.LinkClicked += (s, e) => ShowGitRepo(s, e);
        }

        private void InitializeWebView()
        {
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
                    Logger.HandleError("An error occurred while initializing the WebView", ex);
                }
            }

            Html.DefaultHtml(Helper.IsNetworkAvailable());
            webView.Source = new Uri(HtmlPath);

            // Setup WebView events
            webView.NavigationStarting += WebView_NavigationStarting;
        }

        private void CheckInternetConnection()
        {
            if (Helper.IsNetworkAvailable())
            {
                TTF.Visible = false;
                WOFF2.Visible = false;
                FontBox1.Enabled = false;
                Minify.Visible = false;

                // Setup default download folder
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                FolderName = Path.Combine(desktopPath, "GoogleFonts");
                SelectedFolder.Text = FolderName;
            }
            else
            {
                webView.Reload();
                NoInternet.Visible = true;
            }
        }

        private void LoadApiKey()
        {
            string apiKey = Helper.GetAPIKey();
            if (!string.IsNullOrEmpty(apiKey))
            {
                ApiKeyBox.Text = apiKey;
            }
        }

        private async void SelectFolder_Click(object sender, EventArgs e)
        {
            using var folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Select folder to save Google fonts",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true
            };

            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                FolderName = folderBrowserDialog.SelectedPath;
                SelectedFolder.Text = FolderName;
            }
        }

        private void FontBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string selectedFontFamily = FontBox1.SelectedItem?.ToString();
                var fontSelector = new FontSelector();
                SelectedFontItem = fontSelector?.FontSelection(selectedFontFamily, Items, UpdateUIComponents);
            }
            catch (Exception ex)
            {
                Logger.HandleError("Error selecting font", ex);
            }
        }

        private void UpdateUIComponents(string selectedFontLabel, IEnumerable<string> subsets, IEnumerable<string> variants)
        {
            try
            {
                SubsetsLists.Items.Clear();
                SizeAndStyle.Items.Clear();

                SelectedFontLabel.Text = selectedFontLabel;
                SubsetsLists.Items.AddRange(subsets.ToArray());
                SizeAndStyle.Items.AddRange(variants.ToArray());

                // Ensure WebView is navigated to the correct HTML file
                try
                {
                    webView.CoreWebView2.Navigate(HtmlPath);
                }
                catch (Exception ex)
                {
                    Logger.HandleError("Error navigating WebView", ex);
                }

                Minify.Visible = true;
                Minify.Enabled = true;
            }
            catch (Exception ex)
            {
                Logger.HandleError("Error updating UI components", ex);
            }
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


                // Show loading indicator
                Cursor = Cursors.WaitCursor;

                Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, false);

                if (Items != null && Items.Count != 0)
                {
                    FontBox1.Items.Clear();
                    FontBox1.Items.AddRange(Items.Select(item => item.Family).ToArray());

                    WOFF2.Visible = true;
                    TTF.Visible = true;
                    TTF.Checked = true;
                    FontBox1.Enabled = true;
                    Minify.Visible = true;

                    if (Fonts.FontResponse?.Error == null)
                        webView.Reload();
                }
                else if (Fonts.FontResponse?.Error != null)
                {
                    MessageBox.Show($"API Error: {Fonts.FontResponse.Error.Message}", "API Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Html.DefaultHtml(false, Fonts);
                    webView.Reload();
                    NoInternet.Visible = true;
                }
                else
                {
                    await Task.Run(() => Html.DefaultHtml(false, Fonts));
                    webView.Reload();
                    NoInternet.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Logger.HandleError("An error occurred while processing your request.", ex);
                MessageBox.Show("An error occurred while processing your request. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Hide loading indicator
                Cursor = Cursors.Default;
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
                MessageBox.Show("Please select a folder to save the fonts.");
                return;
            }

            if (SizeAndStyle.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please choose at least one font variant to download.");
                return;
            }

            if (SelectedFontItem is null || SelectedFontItem.Variants is null || SelectedFontItem.Variants.Count == 0)
            {
                Logger.HandleError("Selected font item or its variants are invalid.", new Exception("Invalid font selection."));
                return;
            }

            try
            {
                // Show loading cursor
                Cursor = Cursors.WaitCursor;
                CopyFont.Enabled = false;
                CopyFont.Text = "Downloading...";

                var selectedFont = SelectedFontItem;
                selectedFont.Variants = SizeAndStyle.CheckedItems.Cast<string>().Where(m => !string.IsNullOrEmpty(m)).ToList();
                var css = new CssFile();
                var subsets = SubsetsLists.CheckedItems.Cast<string>().ToArray();

                // Create the CSS file first
                await Task.Run(() => css.CreateCSS(selectedFont, FolderName, WOFF2.Checked, Minify.Checked, subsets));

                // Download the font files
                using (var downloader = new FontFilesDownloader())
                {
                    await downloader.DownloadAsync(selectedFont, FolderName, WOFF2.Checked);
                }

                // Show success message and offer to open the folder
                OpenDownloadFolder(FolderName, selectedFont.Family.Replace(" ", ""));
            }
            catch (Exception ex)
            {
                Logger.HandleError("Download failed", ex);
                MessageBox.Show("There was an error downloading the fonts. Please check the log for details.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Reset UI state
                Cursor = Cursors.Default;
                CopyFont.Enabled = true;
                CopyFont.Text = "Download Font";
            }
        }

        private static void OpenDownloadFolder(string folderName, string fontFolderName)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show(
                    "The download has been completed successfully. Would you like to open the folder containing the downloaded files?",
                    "Download Completed",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes)
                {
                    var folderToOpen = Path.Combine(folderName, fontFolderName);
                    if (Directory.Exists(folderToOpen))
                    {
                        Process.Start("explorer.exe", folderToOpen);
                    }
                    else
                    {
                        MessageBox.Show($"Folder not found: {folderToOpen}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error opening GitHub repository: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Form control events
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
                MessageBox.Show("All comments will be deleted in the minified version", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Cursor = Cursors.WaitCursor;
                    otherBox.Checked = !checkedBox.Checked;
                    Items = await Fonts.GetWebFontsAsync(ApiKeyBox.Text, checkedBox == WOFF2);
                    Cursor = Cursors.Default;
                }
            }
            else
            {
                webView.Reload();
                NoInternet.Visible = true;
            }
        }

        private async void WOFF2_Click(object sender, EventArgs e) => await HandleFontTypeChecked(WOFF2, TTF);
        private async void TTF_Click(object sender, EventArgs e) => await HandleFontTypeChecked(TTF, WOFF2);

        private void SubsetsLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            Minify.Enabled = SubsetsLists.CheckedItems.Count == 0;
        }

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
                Logger.HandleError($"Navigation error: {ex.Message}", ex);
                MessageBox.Show($"An error occurred while opening the link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}