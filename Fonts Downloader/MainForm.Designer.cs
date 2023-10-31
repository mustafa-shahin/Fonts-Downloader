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
            SelectedFont = new Label();
            CopyFont = new Button();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            LeftPanel = new Panel();
            SubsetsLabel = new Label();
            Minify = new CheckBox();
            SubsetsLists = new CheckedListBox();
            WOFF2 = new CheckBox();
            TopPanel = new Panel();
            TTF = new CheckBox();
            ApiKeyLabel = new Label();
            ApiKeyBox = new TextBox();
            WebPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            LeftPanel.SuspendLayout();
            TopPanel.SuspendLayout();
            WebPanel.SuspendLayout();
            SuspendLayout();
            // 
            // SizeAndStyle
            // 
            SizeAndStyle.BackColor = Color.FromArgb(21, 98, 101);
            SizeAndStyle.BorderStyle = BorderStyle.None;
            SizeAndStyle.CheckOnClick = true;
            SizeAndStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SizeAndStyle.ForeColor = Color.White;
            SizeAndStyle.FormattingEnabled = true;
            SizeAndStyle.Location = new Point(20, 110);
            SizeAndStyle.Margin = new Padding(3, 5, 3, 2);
            SizeAndStyle.Name = "SizeAndStyle";
            SizeAndStyle.Size = new Size(237, 325);
            SizeAndStyle.TabIndex = 35;
            // 
            // SelectFolder
            // 
            SelectFolder.Anchor = AnchorStyles.None;
            SelectFolder.BackColor = Color.FromArgb(35, 114, 66);
            SelectFolder.FlatAppearance.BorderColor = Color.FromArgb(35, 114, 66);
            SelectFolder.FlatStyle = FlatStyle.Flat;
            SelectFolder.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point);
            SelectFolder.ForeColor = Color.White;
            SelectFolder.Location = new Point(23, 24);
            SelectFolder.Margin = new Padding(3, 2, 3, 2);
            SelectFolder.Name = "SelectFolder";
            SelectFolder.Size = new Size(121, 35);
            SelectFolder.TabIndex = 30;
            SelectFolder.Text = "Select Folder";
            SelectFolder.UseVisualStyleBackColor = false;
            SelectFolder.Click += SelectFolder_Click;
            // 
            // SelectedFolder
            // 
            SelectedFolder.Anchor = AnchorStyles.None;
            SelectedFolder.BackColor = Color.White;
            SelectedFolder.BorderStyle = BorderStyle.None;
            SelectedFolder.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectedFolder.Location = new Point(173, 24);
            SelectedFolder.Margin = new Padding(3, 2, 3, 2);
            SelectedFolder.Multiline = true;
            SelectedFolder.Name = "SelectedFolder";
            SelectedFolder.Size = new Size(528, 35);
            SelectedFolder.TabIndex = 31;
            // 
            // FontBox1
            // 
            FontBox1.BackColor = Color.FromArgb(21, 98, 101);
            FontBox1.FlatStyle = FlatStyle.Flat;
            FontBox1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            FontBox1.ForeColor = Color.White;
            FontBox1.FormattingEnabled = true;
            FontBox1.Location = new Point(20, 30);
            FontBox1.Margin = new Padding(3, 2, 3, 2);
            FontBox1.Name = "FontBox1";
            FontBox1.Size = new Size(237, 28);
            FontBox1.TabIndex = 32;
            FontBox1.Text = "Selected Font";
            FontBox1.SelectionChangeCommitted += FontBox1_SelectionChangeCommitted;
            // 
            // SelectedFont
            // 
            SelectedFont.AutoSize = true;
            SelectedFont.FlatStyle = FlatStyle.Flat;
            SelectedFont.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SelectedFont.ForeColor = Color.White;
            SelectedFont.Location = new Point(20, 80);
            SelectedFont.Name = "SelectedFont";
            SelectedFont.Size = new Size(51, 25);
            SelectedFont.TabIndex = 33;
            SelectedFont.Text = "Font";
            // 
            // CopyFont
            // 
            CopyFont.Anchor = AnchorStyles.None;
            CopyFont.AutoSize = true;
            CopyFont.BackColor = Color.FromArgb(35, 114, 66);
            CopyFont.FlatAppearance.BorderColor = Color.FromArgb(35, 114, 66);
            CopyFont.FlatStyle = FlatStyle.Flat;
            CopyFont.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            CopyFont.ForeColor = Color.White;
            CopyFont.Location = new Point(20, 866);
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
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.FromArgb(45, 62, 79);
            webView21.Dock = DockStyle.Fill;
            webView21.ForeColor = Color.White;
            webView21.Location = new Point(0, 0);
            webView21.Margin = new Padding(3, 5, 3, 5);
            webView21.Name = "webView21";
            webView21.Size = new Size(950, 766);
            webView21.TabIndex = 35;
            webView21.ZoomFactor = 1D;
            webView21.CoreWebView2InitializationCompleted += WebView21_CoreWebView2InitializationCompleted;
            // 
            // LeftPanel
            // 
            LeftPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LeftPanel.BackColor = Color.FromArgb(45, 62, 79);
            LeftPanel.Controls.Add(SubsetsLabel);
            LeftPanel.Controls.Add(Minify);
            LeftPanel.Controls.Add(CopyFont);
            LeftPanel.Controls.Add(SubsetsLists);
            LeftPanel.Controls.Add(SelectedFont);
            LeftPanel.Controls.Add(SizeAndStyle);
            LeftPanel.Controls.Add(FontBox1);
            LeftPanel.Location = new Point(12, 19);
            LeftPanel.Margin = new Padding(3, 5, 3, 5);
            LeftPanel.Name = "LeftPanel";
            LeftPanel.Size = new Size(274, 932);
            LeftPanel.TabIndex = 36;
            // 
            // SubsetsLabel
            // 
            SubsetsLabel.AutoSize = true;
            SubsetsLabel.FlatStyle = FlatStyle.Flat;
            SubsetsLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SubsetsLabel.ForeColor = Color.White;
            SubsetsLabel.Location = new Point(20, 458);
            SubsetsLabel.Name = "SubsetsLabel";
            SubsetsLabel.Size = new Size(84, 25);
            SubsetsLabel.TabIndex = 52;
            SubsetsLabel.Text = "Subsets";
            // 
            // Minify
            // 
            Minify.Anchor = AnchorStyles.None;
            Minify.AutoSize = true;
            Minify.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Minify.Location = new Point(20, 820);
            Minify.Margin = new Padding(3, 5, 3, 5);
            Minify.Name = "Minify";
            Minify.Size = new Size(136, 29);
            Minify.TabIndex = 51;
            Minify.Text = "Minified css";
            Minify.UseVisualStyleBackColor = true;
            Minify.CheckedChanged += Minify_CheckedChanged;
            // 
            // SubsetsLists
            // 
            SubsetsLists.BackColor = Color.FromArgb(21, 98, 101);
            SubsetsLists.BorderStyle = BorderStyle.None;
            SubsetsLists.CheckOnClick = true;
            SubsetsLists.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            SubsetsLists.ForeColor = Color.White;
            SubsetsLists.FormattingEnabled = true;
            SubsetsLists.Location = new Point(20, 488);
            SubsetsLists.Margin = new Padding(3, 5, 3, 2);
            SubsetsLists.Name = "SubsetsLists";
            SubsetsLists.Size = new Size(237, 325);
            SubsetsLists.TabIndex = 50;
            SubsetsLists.ItemCheck += SubsetsLists_ItemCheck;
            // 
            // WOFF2
            // 
            WOFF2.Anchor = AnchorStyles.None;
            WOFF2.AutoSize = true;
            WOFF2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            WOFF2.ForeColor = Color.FromArgb(155, 43, 34);
            WOFF2.Location = new Point(785, 30);
            WOFF2.Margin = new Padding(3, 5, 3, 5);
            WOFF2.Name = "WOFF2";
            WOFF2.Size = new Size(105, 29);
            WOFF2.TabIndex = 52;
            WOFF2.Text = "WOFF2";
            WOFF2.UseVisualStyleBackColor = true;
            WOFF2.CheckedChanged += WOFF2_CheckedChanged;
            // 
            // TopPanel
            // 
            TopPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TopPanel.BackColor = Color.FromArgb(45, 62, 79);
            TopPanel.Controls.Add(TTF);
            TopPanel.Controls.Add(ApiKeyLabel);
            TopPanel.Controls.Add(WOFF2);
            TopPanel.Controls.Add(ApiKeyBox);
            TopPanel.Controls.Add(SelectFolder);
            TopPanel.Controls.Add(SelectedFolder);
            TopPanel.Location = new Point(292, 19);
            TopPanel.Margin = new Padding(3, 5, 3, 5);
            TopPanel.Name = "TopPanel";
            TopPanel.Size = new Size(950, 156);
            TopPanel.TabIndex = 37;
            // 
            // TTF
            // 
            TTF.Anchor = AnchorStyles.None;
            TTF.AutoSize = true;
            TTF.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TTF.ForeColor = Color.FromArgb(155, 43, 34);
            TTF.Location = new Point(785, 95);
            TTF.Margin = new Padding(3, 5, 3, 5);
            TTF.Name = "TTF";
            TTF.Size = new Size(72, 29);
            TTF.TabIndex = 53;
            TTF.Text = "TTF";
            TTF.UseVisualStyleBackColor = true;
            TTF.CheckedChanged += TTF_CheckedChanged;
            // 
            // ApiKeyLabel
            // 
            ApiKeyLabel.Anchor = AnchorStyles.None;
            ApiKeyLabel.AutoSize = true;
            ApiKeyLabel.FlatStyle = FlatStyle.Flat;
            ApiKeyLabel.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyLabel.ForeColor = Color.White;
            ApiKeyLabel.Location = new Point(63, 89);
            ApiKeyLabel.Name = "ApiKeyLabel";
            ApiKeyLabel.Size = new Size(81, 25);
            ApiKeyLabel.TabIndex = 35;
            ApiKeyLabel.Text = "Api Key";
            // 
            // ApiKeyBox
            // 
            ApiKeyBox.Anchor = AnchorStyles.None;
            ApiKeyBox.BackColor = Color.White;
            ApiKeyBox.BorderStyle = BorderStyle.None;
            ApiKeyBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            ApiKeyBox.Location = new Point(173, 89);
            ApiKeyBox.Margin = new Padding(3, 2, 3, 2);
            ApiKeyBox.Multiline = true;
            ApiKeyBox.Name = "ApiKeyBox";
            ApiKeyBox.Size = new Size(528, 35);
            ApiKeyBox.TabIndex = 32;
            ApiKeyBox.TextChanged += TextBox2_TextChanged;
            // 
            // WebPanel
            // 
            WebPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WebPanel.BackColor = Color.FromArgb(45, 62, 79);
            WebPanel.Controls.Add(webView21);
            WebPanel.ForeColor = Color.White;
            WebPanel.Location = new Point(292, 185);
            WebPanel.Margin = new Padding(3, 5, 3, 5);
            WebPanel.Name = "WebPanel";
            WebPanel.Size = new Size(950, 766);
            WebPanel.TabIndex = 38;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(1254, 965);
            Controls.Add(WebPanel);
            Controls.Add(TopPanel);
            Controls.Add(LeftPanel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            Text = "Fonts Downloader";
            WindowState = FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            LeftPanel.ResumeLayout(false);
            LeftPanel.PerformLayout();
            TopPanel.ResumeLayout(false);
            TopPanel.PerformLayout();
            WebPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private CheckedListBox SizeAndStyle;
        private Button SelectFolder;
        private TextBox SelectedFolder;
        private ComboBox FontBox1;
        private Label SelectedFont;
        private Button CopyFont;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel LeftPanel;
        private Panel TopPanel;
        private Panel WebPanel;
        private Label ApiKeyLabel;
        private TextBox ApiKeyBox;
        private CheckedListBox SubsetsLists;
        private CheckBox Minify;
        private CheckBox WOFF2;
        private CheckBox TTF;
        private Label SubsetsLabel;
    }
}
