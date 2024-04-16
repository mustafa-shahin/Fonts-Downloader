using System.Drawing;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    partial class MainForm
    {


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SizeAndStyle = new CheckedListBox();
            SelectFolder = new Button();
            SelectedFolder = new TextBox();
            FontBox1 = new ComboBox();
            SelectedFontLabel = new Label();
            CopyFont = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            LeftPanel = new Panel();
            Minify = new CheckBox();
            TTF = new CheckBox();
            SubsetsLabel = new Label();
            WOFF2 = new CheckBox();
            SubsetsLists = new CheckedListBox();
            TopPanel = new Panel();
            TextBoxPanel = new Panel();
            ApiKeyBox = new TextBox();
            GitPanel = new Panel();
            PanelGitIcon = new Panel();
            GitPic = new PictureBox();
            LinkPanel = new Panel();
            GitHubLink = new LinkLabel();
            WebPanel = new Panel();
            NoInternet = new PictureBox();
            Header = new Panel();
            TitlePanel = new Panel();
            pictureBox1 = new PictureBox();
            Titel = new Label();
            panel1 = new Panel();
            Maximize = new Button();
            Close = new Button();
            Minimize = new Button();
            MainPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            LeftPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            TextBoxPanel.SuspendLayout();
            GitPanel.SuspendLayout();
            PanelGitIcon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GitPic).BeginInit();
            LinkPanel.SuspendLayout();
            WebPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NoInternet).BeginInit();
            Header.SuspendLayout();
            TitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            MainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SizeAndStyle
            // 
            SizeAndStyle.BackColor = Color.FromArgb(38, 42, 49);
            SizeAndStyle.BorderStyle = BorderStyle.None;
            SizeAndStyle.CheckOnClick = true;
            SizeAndStyle.Font = new Font("Microsoft Sans Serif", 12F);
            SizeAndStyle.ForeColor = Color.FromArgb(185, 185, 185);
            SizeAndStyle.FormattingEnabled = true;
            SizeAndStyle.Location = new Point(17, 94);
            SizeAndStyle.Margin = new Padding(3, 5, 3, 2);
            SizeAndStyle.Name = "SizeAndStyle";
            SizeAndStyle.Size = new Size(237, 325);
            SizeAndStyle.TabIndex = 35;
            // 
            // SelectFolder
            // 
            SelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SelectFolder.BackColor = Color.FromArgb(18, 163, 255);
            SelectFolder.FlatAppearance.BorderColor = Color.FromArgb(35, 114, 66);
            SelectFolder.FlatStyle = FlatStyle.Flat;
            SelectFolder.Font = new Font("Microsoft Sans Serif", 8F);
            SelectFolder.ForeColor = Color.White;
            SelectFolder.Location = new Point(77, 18);
            SelectFolder.Margin = new Padding(3, 2, 3, 2);
            SelectFolder.Name = "SelectFolder";
            SelectFolder.Size = new Size(157, 40);
            SelectFolder.TabIndex = 30;
            SelectFolder.Text = "Select Folder";
            SelectFolder.UseVisualStyleBackColor = false;
            SelectFolder.Click += SelectFolder_Click;
            // 
            // SelectedFolder
            // 
            SelectedFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SelectedFolder.BackColor = Color.FromArgb(38, 42, 49);
            SelectedFolder.BorderStyle = BorderStyle.None;
            SelectedFolder.Font = new Font("Microsoft Sans Serif", 16.2F);
            SelectedFolder.ForeColor = Color.FromArgb(185, 185, 185);
            SelectedFolder.Location = new Point(250, 17);
            SelectedFolder.Margin = new Padding(3, 2, 3, 2);
            SelectedFolder.Multiline = true;
            SelectedFolder.Name = "SelectedFolder";
            SelectedFolder.PlaceholderText = "Selected Folder";
            SelectedFolder.Size = new Size(620, 40);
            SelectedFolder.TabIndex = 31;
            // 
            // FontBox1
            // 
            FontBox1.BackColor = Color.FromArgb(38, 42, 49);
            FontBox1.FlatStyle = FlatStyle.Flat;
            FontBox1.Font = new Font("Microsoft Sans Serif", 10F);
            FontBox1.ForeColor = Color.FromArgb(185, 185, 185);
            FontBox1.FormattingEnabled = true;
            FontBox1.Location = new Point(17, 13);
            FontBox1.Margin = new Padding(3, 2, 3, 2);
            FontBox1.Name = "FontBox1";
            FontBox1.Size = new Size(237, 28);
            FontBox1.TabIndex = 32;
            FontBox1.Text = "Selected Font";
            FontBox1.SelectionChangeCommitted += FontBox1_SelectionChangeCommitted;
            // 
            // SelectedFontLabel
            // 
            SelectedFontLabel.AutoSize = true;
            SelectedFontLabel.FlatStyle = FlatStyle.Flat;
            SelectedFontLabel.Font = new Font("Microsoft Sans Serif", 12F);
            SelectedFontLabel.ForeColor = Color.FromArgb(185, 185, 185);
            SelectedFontLabel.Location = new Point(17, 64);
            SelectedFontLabel.Name = "SelectedFontLabel";
            SelectedFontLabel.Size = new Size(51, 25);
            SelectedFontLabel.TabIndex = 33;
            SelectedFontLabel.Text = "Font";
            // 
            // CopyFont
            // 
            CopyFont.Anchor = AnchorStyles.None;
            CopyFont.AutoSize = true;
            CopyFont.BackColor = Color.FromArgb(18, 163, 255);
            CopyFont.FlatAppearance.BorderColor = Color.FromArgb(35, 114, 66);
            CopyFont.FlatStyle = FlatStyle.Flat;
            CopyFont.Font = new Font("Microsoft Sans Serif", 10F);
            CopyFont.ForeColor = Color.White;
            CopyFont.Location = new Point(17, 850);
            CopyFont.Margin = new Padding(3, 2, 3, 2);
            CopyFont.Name = "CopyFont";
            CopyFont.Size = new Size(237, 48);
            CopyFont.TabIndex = 34;
            CopyFont.Text = "Download Font";
            CopyFont.UseVisualStyleBackColor = false;
            CopyFont.Click += CopyFont_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.BackColor = Color.FromArgb(33, 33, 36);
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.FromArgb(32, 33, 36);
            webView21.Dock = DockStyle.Fill;
            webView21.ForeColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Margin = new Padding(3, 5, 3, 5);
            webView21.Name = "webView21";
            webView21.Size = new Size(1111, 757);
            webView21.TabIndex = 35;
            webView21.ZoomFactor = 1D;
            // 
            // LeftPanel
            // 
            LeftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LeftPanel.BackColor = Color.FromArgb(33, 33, 36);
            LeftPanel.Controls.Add(Minify);
            LeftPanel.Controls.Add(TTF);
            LeftPanel.Controls.Add(CopyFont);
            LeftPanel.Controls.Add(SubsetsLabel);
            LeftPanel.Controls.Add(WOFF2);
            LeftPanel.Controls.Add(SelectedFontLabel);
            LeftPanel.Controls.Add(SubsetsLists);
            LeftPanel.Controls.Add(SizeAndStyle);
            LeftPanel.Controls.Add(FontBox1);
            LeftPanel.Location = new Point(12, 15);
            LeftPanel.Margin = new Padding(3, 5, 3, 5);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(269, 907);
            LeftPanel.TabIndex = 36;
            // 
            // Minify
            // 
            Minify.Anchor = AnchorStyles.None;
            Minify.AutoSize = true;
            Minify.Font = new Font("Microsoft Sans Serif", 12F);
            Minify.ForeColor = Color.FromArgb(185, 185, 185);
            Minify.Location = new Point(17, 772);
            Minify.Margin = new Padding(3, 5, 3, 5);
            Minify.Name = "Minify";
            Minify.Size = new Size(136, 29);
            Minify.TabIndex = 51;
            Minify.Text = "Minified css";
            Minify.UseVisualStyleBackColor = true;
            Minify.CheckedChanged += Minify_CheckedChanged;
            // 
            // TTF
            // 
            TTF.Anchor = AnchorStyles.None;
            TTF.AutoSize = true;
            TTF.Font = new Font("Microsoft Sans Serif", 13.8F);
            TTF.ForeColor = Color.FromArgb(185, 185, 185);
            TTF.Location = new Point(172, 799);
            TTF.Margin = new Padding(3, 5, 3, 5);
            TTF.Name = "TTF";
            TTF.Size = new Size(82, 33);
            TTF.TabIndex = 53;
            TTF.Text = "TTF";
            TTF.UseVisualStyleBackColor = true;
            TTF.CheckedChanged += TTF_Checked;
            // 
            // SubsetsLabel
            // 
            SubsetsLabel.AutoSize = true;
            SubsetsLabel.FlatStyle = FlatStyle.Flat;
            SubsetsLabel.Font = new Font("Microsoft Sans Serif", 12F);
            SubsetsLabel.ForeColor = Color.FromArgb(185, 185, 185);
            SubsetsLabel.Location = new Point(17, 435);
            SubsetsLabel.Name = "SubsetsLabel";
            SubsetsLabel.Size = new Size(84, 25);
            SubsetsLabel.TabIndex = 52;
            SubsetsLabel.Text = "Subsets";
            // 
            // WOFF2
            // 
            WOFF2.Anchor = AnchorStyles.None;
            WOFF2.AutoSize = true;
            WOFF2.Font = new Font("Microsoft Sans Serif", 12F);
            WOFF2.ForeColor = Color.FromArgb(185, 185, 185);
            WOFF2.Location = new Point(17, 803);
            WOFF2.Margin = new Padding(3, 5, 3, 5);
            WOFF2.Name = "WOFF2";
            WOFF2.Size = new Size(105, 29);
            WOFF2.TabIndex = 52;
            WOFF2.Text = "WOFF2";
            WOFF2.UseVisualStyleBackColor = true;
            WOFF2.CheckedChanged += WOFF2_Checked;
            // 
            // SubsetsLists
            // 
            SubsetsLists.BackColor = Color.FromArgb(38, 42, 49);
            SubsetsLists.BorderStyle = BorderStyle.None;
            SubsetsLists.CheckOnClick = true;
            SubsetsLists.Font = new Font("Microsoft Sans Serif", 12F);
            SubsetsLists.ForeColor = Color.FromArgb(185, 185, 185);
            SubsetsLists.FormattingEnabled = true;
            SubsetsLists.Location = new Point(17, 465);
            SubsetsLists.Margin = new Padding(3, 5, 3, 2);
            SubsetsLists.Name = "SubsetsLists";
            SubsetsLists.Size = new Size(237, 300);
            SubsetsLists.TabIndex = 50;
            SubsetsLists.SelectedIndexChanged += SubsetsLists_SelectedIndexChanged;
            // 
            // TopPanel
            // 
            TopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopPanel.BackColor = Color.FromArgb(32, 33, 36);
            TopPanel.Controls.Add(TextBoxPanel);
            TopPanel.Controls.Add(GitPanel);
            TopPanel.Location = new Point(293, 14);
            TopPanel.Margin = new Padding(3, 5, 3, 5);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(1111, 131);
            TopPanel.TabIndex = 37;
            // 
            // TextBoxPanel
            // 
            TextBoxPanel.BackColor = Color.FromArgb(33, 33, 36);
            TextBoxPanel.Controls.Add(ApiKeyBox);
            TextBoxPanel.Controls.Add(SelectFolder);
            TextBoxPanel.Controls.Add(SelectedFolder);
            TextBoxPanel.Dock = DockStyle.Left;
            TextBoxPanel.Location = new Point(0, 0);
            TextBoxPanel.Name = "TextBoxPanel";
            TextBoxPanel.Size = new Size(950, 131);
            TextBoxPanel.TabIndex = 57;
            // 
            // ApiKeyBox
            // 
            ApiKeyBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ApiKeyBox.BackColor = Color.FromArgb(38, 42, 49);
            ApiKeyBox.BorderStyle = BorderStyle.None;
            ApiKeyBox.Font = new Font("Microsoft Sans Serif", 13.8F);
            ApiKeyBox.ForeColor = Color.FromArgb(185, 185, 185);
            ApiKeyBox.Location = new Point(250, 64);
            ApiKeyBox.Margin = new Padding(3, 2, 3, 2);
            ApiKeyBox.Multiline = true;
            ApiKeyBox.Name = "ApiKeyBox";
            ApiKeyBox.PlaceholderText = "API KEY";
            ApiKeyBox.Size = new Size(618, 40);
            ApiKeyBox.TabIndex = 32;
            ApiKeyBox.TextChanged += TextBox2_TextChanged;
            // 
            // GitPanel
            // 
            GitPanel.Controls.Add(PanelGitIcon);
            GitPanel.Controls.Add(LinkPanel);
            GitPanel.Dock = DockStyle.Right;
            GitPanel.Location = new Point(950, 0);
            GitPanel.Name = "GitPanel";
            GitPanel.Size = new Size(161, 131);
            GitPanel.TabIndex = 56;
            // 
            // PanelGitIcon
            // 
            PanelGitIcon.Anchor = AnchorStyles.Top;
            PanelGitIcon.Controls.Add(GitPic);
            PanelGitIcon.Location = new Point(47, 5);
            PanelGitIcon.Name = "PanelGitIcon";
            PanelGitIcon.Size = new Size(91, 70);
            PanelGitIcon.TabIndex = 37;
            // 
            // GitPic
            // 
            GitPic.Dock = DockStyle.Fill;
            GitPic.Image = (Image)resources.GetObject("GitPic.Image");
            GitPic.Location = new Point(0, 0);
            GitPic.Name = "GitPic";
            GitPic.Size = new Size(91, 70);
            GitPic.SizeMode = PictureBoxSizeMode.Zoom;
            GitPic.TabIndex = 54;
            GitPic.TabStop = false;
            GitPic.Click += MainForm.ShowGitRepo;
            // 
            // LinkPanel
            // 
            LinkPanel.Controls.Add(GitHubLink);
            LinkPanel.Dock = DockStyle.Fill;
            LinkPanel.Location = new Point(0, 0);
            LinkPanel.Name = "LinkPanel";
            LinkPanel.Size = new Size(161, 131);
            LinkPanel.TabIndex = 37;
            // 
            // GitHubLink
            // 
            GitHubLink.ActiveLinkColor = Color.White;
            GitHubLink.Anchor = AnchorStyles.None;
            GitHubLink.AutoSize = true;
            GitHubLink.Font = new Font("Microsoft Sans Serif", 12F);
            GitHubLink.ForeColor = Color.White;
            GitHubLink.LinkBehavior = LinkBehavior.NeverUnderline;
            GitHubLink.LinkColor = Color.White;
            GitHubLink.Location = new Point(64, 95);
            GitHubLink.Name = "GitHubLink";
            GitHubLink.Size = new Size(60, 25);
            GitHubLink.TabIndex = 55;
            GitHubLink.TabStop = true;
            GitHubLink.Text = "Code";
            GitHubLink.VisitedLinkColor = Color.White;
            GitHubLink.Click += MainForm.ShowGitRepo;
            // 
            // WebPanel
            // 
            WebPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WebPanel.BackColor = Color.FromArgb(32, 33, 36);
            WebPanel.Controls.Add(NoInternet);
            WebPanel.Controls.Add(webView21);
            WebPanel.ForeColor = Color.FromArgb(142, 181, 245);
            WebPanel.Location = new Point(293, 165);
            WebPanel.Margin = new Padding(3, 5, 3, 5);
            WebPanel.Name = "WebPanel";
            WebPanel.Size = new Size(1111, 757);
            WebPanel.TabIndex = 38;
            // 
            // NoInternet
            // 
            NoInternet.Image = (Image)resources.GetObject("NoInternet.Image");
            NoInternet.Location = new Point(338, 228);
            NoInternet.Name = "NoInternet";
            NoInternet.Size = new Size(469, 314);
            NoInternet.SizeMode = PictureBoxSizeMode.Zoom;
            NoInternet.TabIndex = 36;
            NoInternet.TabStop = false;
            NoInternet.Visible = false;
            NoInternet.Click += NoInternet_Click;
            // 
            // Header
            // 
            Header.BackColor = Color.FromArgb(40, 41, 42);
            Header.Controls.Add(TitlePanel);
            Header.Controls.Add(panel1);
            Header.Dock = DockStyle.Top;
            Header.Location = new Point(0, 0);
            Header.Name = "Header";
            Header.Size = new Size(1416, 58);
            Header.TabIndex = 39;
            Header.MouseDown += Header_MouseDown;
            Header.MouseMove += MouseMove;
            Header.MouseUp += Header_MouseUp;
            // 
            // TitlePanel
            // 
            TitlePanel.Controls.Add(pictureBox1);
            TitlePanel.Controls.Add(Titel);
            TitlePanel.Dock = DockStyle.Left;
            TitlePanel.Location = new Point(0, 0);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new Size(295, 58);
            TitlePanel.TabIndex = 2;
            TitlePanel.MouseMove += MouseMove;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 56;
            pictureBox1.TabStop = false;
            pictureBox1.MouseMove += MouseMove;
            // 
            // Titel
            // 
            Titel.AutoSize = true;
            Titel.Font = new Font("Segoe UI", 13.8F);
            Titel.ForeColor = Color.FromArgb(185, 185, 185);
            Titel.Location = new Point(93, 12);
            Titel.Name = "Titel";
            Titel.Size = new Size(199, 31);
            Titel.TabIndex = 1;
            Titel.Text = "Fonts Downloader";
            Titel.MouseMove += MouseMove;
            // 
            // panel1
            // 
            panel1.Controls.Add(Maximize);
            panel1.Controls.Add(Close);
            panel1.Controls.Add(Minimize);
            panel1.Dock = DockStyle.Right;
            panel1.ForeColor = Color.FromArgb(40, 41, 42);
            panel1.Location = new Point(1243, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(173, 58);
            panel1.TabIndex = 0;
            // 
            // Maximize
            // 
            Maximize.BackColor = Color.FromArgb(40, 41, 42);
            Maximize.BackgroundImage = (Image)resources.GetObject("Maximize.BackgroundImage");
            Maximize.BackgroundImageLayout = ImageLayout.Zoom;
            Maximize.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 41, 42);
            Maximize.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 41, 42);
            Maximize.FlatStyle = FlatStyle.Flat;
            Maximize.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            Maximize.ForeColor = Color.FromArgb(40, 41, 42);
            Maximize.Location = new Point(17, 7);
            Maximize.Name = "Maximize";
            Maximize.Size = new Size(46, 45);
            Maximize.TabIndex = 2;
            Maximize.UseVisualStyleBackColor = false;
            Maximize.Visible = false;
            // 
            // Close
            // 
            Close.BackgroundImage = (Image)resources.GetObject("Close.BackgroundImage");
            Close.BackgroundImageLayout = ImageLayout.Zoom;
            Close.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 41, 42);
            Close.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 41, 42);
            Close.FlatStyle = FlatStyle.Flat;
            Close.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            Close.ForeColor = Color.FromArgb(40, 41, 42);
            Close.Location = new Point(112, 7);
            Close.Name = "Close";
            Close.Size = new Size(46, 45);
            Close.TabIndex = 0;
            Close.UseVisualStyleBackColor = false;
            Close.Click += Close_Click;
            // 
            // Minimize
            // 
            Minimize.BackColor = Color.FromArgb(40, 41, 42);
            Minimize.BackgroundImage = (Image)resources.GetObject("Minimize.BackgroundImage");
            Minimize.BackgroundImageLayout = ImageLayout.Zoom;
            Minimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(40, 41, 42);
            Minimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 41, 42);
            Minimize.FlatStyle = FlatStyle.Flat;
            Minimize.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold);
            Minimize.ForeColor = Color.FromArgb(40, 41, 42);
            Minimize.Location = new Point(64, 7);
            Minimize.Name = "Minimize";
            Minimize.Size = new Size(46, 45);
            Minimize.TabIndex = 1;
            Minimize.UseVisualStyleBackColor = false;
            Minimize.Click += Minimize_Click;
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.FromArgb(31, 31, 31);
            MainPanel.Controls.Add(WebPanel);
            MainPanel.Controls.Add(LeftPanel);
            MainPanel.Controls.Add(TopPanel);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 58);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1416, 941);
            MainPanel.TabIndex = 40;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(32, 33, 36);
            ClientSize = new Size(1416, 999);
            Controls.Add(MainPanel);
            Controls.Add(Header);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Fonts Downloader";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            TopPanel.ResumeLayout(false);
            TextBoxPanel.ResumeLayout(false);
            TextBoxPanel.PerformLayout();
            GitPanel.ResumeLayout(false);
            PanelGitIcon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)GitPic).EndInit();
            LinkPanel.ResumeLayout(false);
            LinkPanel.PerformLayout();
            WebPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)NoInternet).EndInit();
            Header.ResumeLayout(false);
            TitlePanel.ResumeLayout(false);
            TitlePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            MainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private CheckedListBox SizeAndStyle;
        private Button SelectFolder;
        private TextBox SelectedFolder;
        private ComboBox FontBox1;
        private Label SelectedFontLabel;
        private Button CopyFont;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel LeftPanel;
        private Panel TopPanel;
        private Panel WebPanel;
        private TextBox ApiKeyBox;
        private CheckedListBox SubsetsLists;
        private CheckBox Minify;
        private CheckBox WOFF2;
        private CheckBox TTF;
        private Label SubsetsLabel;
        private PictureBox GitPic;
        private LinkLabel GitHubLink;
        private Panel GitPanel;
        private Panel Header;
        private new Button Close;
        private Button Minimize;
        private Panel panel1;
        private Panel TextBoxPanel;
        private Panel MainPanel;
        private Button Maximize;
        private Label Titel;
        private Panel TitlePanel;
        private PictureBox pictureBox1;
        private PictureBox NoInternet;
        private Panel LinkPanel;
        private Panel PanelGitIcon;
    }
}
