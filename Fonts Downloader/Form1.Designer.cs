using System.Drawing;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SizeAndStyle = new System.Windows.Forms.CheckedListBox();
            this.SelectFolder = new System.Windows.Forms.Button();
            this.SelectedFolder = new System.Windows.Forms.TextBox();
            this.FontBox1 = new System.Windows.Forms.ComboBox();
            this.SelectedFont = new System.Windows.Forms.Label();
            this.CopyFont = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.SubsetsLists = new System.Windows.Forms.CheckedListBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.ApiKeyLabel = new System.Windows.Forms.Label();
            this.ApiKeyBox = new System.Windows.Forms.TextBox();
            this.WebPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.LeftPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.WebPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeAndStyle
            // 
            this.SizeAndStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.SizeAndStyle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SizeAndStyle.CheckOnClick = true;
            this.SizeAndStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeAndStyle.ForeColor = System.Drawing.Color.White;
            this.SizeAndStyle.FormattingEnabled = true;
            this.SizeAndStyle.Location = new System.Drawing.Point(20, 82);
            this.SizeAndStyle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.SizeAndStyle.Name = "SizeAndStyle";
            this.SizeAndStyle.Size = new System.Drawing.Size(237, 350);
            this.SizeAndStyle.TabIndex = 35;
            // 
            // SelectFolder
            // 
            this.SelectFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.SelectFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFolder.ForeColor = System.Drawing.Color.White;
            this.SelectFolder.Location = new System.Drawing.Point(131, 15);
            this.SelectFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(121, 32);
            this.SelectFolder.TabIndex = 30;
            this.SelectFolder.Text = "Select Folder";
            this.SelectFolder.UseVisualStyleBackColor = false;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // SelectedFolder
            // 
            this.SelectedFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.SelectedFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.SelectedFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelectedFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolder.Location = new System.Drawing.Point(272, 15);
            this.SelectedFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectedFolder.Multiline = true;
            this.SelectedFolder.Name = "SelectedFolder";
            this.SelectedFolder.Size = new System.Drawing.Size(528, 32);
            this.SelectedFolder.TabIndex = 31;
            // 
            // FontBox1
            // 
            this.FontBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.FontBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FontBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontBox1.ForeColor = System.Drawing.Color.White;
            this.FontBox1.FormattingEnabled = true;
            this.FontBox1.Location = new System.Drawing.Point(20, 19);
            this.FontBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FontBox1.Name = "FontBox1";
            this.FontBox1.Size = new System.Drawing.Size(237, 28);
            this.FontBox1.TabIndex = 32;
            this.FontBox1.SelectionChangeCommitted += new System.EventHandler(this.FontBox1_SelectionChangeCommitted);
            // 
            // SelectedFont
            // 
            this.SelectedFont.AutoSize = true;
            this.SelectedFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectedFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFont.ForeColor = System.Drawing.Color.White;
            this.SelectedFont.Location = new System.Drawing.Point(16, 60);
            this.SelectedFont.Name = "SelectedFont";
            this.SelectedFont.Size = new System.Drawing.Size(42, 20);
            this.SelectedFont.TabIndex = 33;
            this.SelectedFont.Text = "Font";
            // 
            // CopyFont
            // 
            this.CopyFont.AutoSize = true;
            this.CopyFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.CopyFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.CopyFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyFont.ForeColor = System.Drawing.Color.White;
            this.CopyFont.Location = new System.Drawing.Point(20, 740);
            this.CopyFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CopyFont.Name = "CopyFont";
            this.CopyFont.Size = new System.Drawing.Size(237, 51);
            this.CopyFont.TabIndex = 34;
            this.CopyFont.Text = "Download Font";
            this.CopyFont.UseVisualStyleBackColor = false;
            this.CopyFont.Click += new System.EventHandler(this.CopyFont_Click);
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.webView21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView21.ForeColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(0, 0);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(950, 702);
            this.webView21.TabIndex = 35;
            this.webView21.ZoomFactor = 1D;
            this.webView21.CoreWebView2InitializationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs>(this.webView21_CoreWebView2InitializationCompleted);
            // 
            // LeftPanel
            // 
            this.LeftPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.LeftPanel.Controls.Add(this.SubsetsLists);
            this.LeftPanel.Controls.Add(this.CopyFont);
            this.LeftPanel.Controls.Add(this.SelectedFont);
            this.LeftPanel.Controls.Add(this.SizeAndStyle);
            this.LeftPanel.Controls.Add(this.FontBox1);
            this.LeftPanel.Location = new System.Drawing.Point(12, 12);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(274, 808);
            this.LeftPanel.TabIndex = 36;
            // 
            // SubsetsLists
            // 
            this.SubsetsLists.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.SubsetsLists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SubsetsLists.CheckOnClick = true;
            this.SubsetsLists.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubsetsLists.ForeColor = System.Drawing.Color.White;
            this.SubsetsLists.FormattingEnabled = true;
            this.SubsetsLists.Location = new System.Drawing.Point(19, 454);
            this.SubsetsLists.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.SubsetsLists.Name = "SubsetsLists";
            this.SubsetsLists.Size = new System.Drawing.Size(237, 275);
            this.SubsetsLists.TabIndex = 50;
            // 
            // TopPanel
            // 
            this.TopPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.TopPanel.Controls.Add(this.ApiKeyLabel);
            this.TopPanel.Controls.Add(this.ApiKeyBox);
            this.TopPanel.Controls.Add(this.SelectFolder);
            this.TopPanel.Controls.Add(this.SelectedFolder);
            this.TopPanel.Location = new System.Drawing.Point(292, 12);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(950, 100);
            this.TopPanel.TabIndex = 37;
            // 
            // ApiKeyLabel
            // 
            this.ApiKeyLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ApiKeyLabel.AutoSize = true;
            this.ApiKeyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApiKeyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApiKeyLabel.ForeColor = System.Drawing.Color.White;
            this.ApiKeyLabel.Location = new System.Drawing.Point(186, 60);
            this.ApiKeyLabel.Name = "ApiKeyLabel";
            this.ApiKeyLabel.Size = new System.Drawing.Size(66, 20);
            this.ApiKeyLabel.TabIndex = 35;
            this.ApiKeyLabel.Text = "Api Key";
            // 
            // ApiKeyBox
            // 
            this.ApiKeyBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ApiKeyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.ApiKeyBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ApiKeyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ApiKeyBox.Location = new System.Drawing.Point(272, 56);
            this.ApiKeyBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ApiKeyBox.Multiline = true;
            this.ApiKeyBox.Name = "ApiKeyBox";
            this.ApiKeyBox.Size = new System.Drawing.Size(528, 32);
            this.ApiKeyBox.TabIndex = 32;
            this.ApiKeyBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // WebPanel
            // 
            this.WebPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.WebPanel.Controls.Add(this.webView21);
            this.WebPanel.ForeColor = System.Drawing.Color.White;
            this.WebPanel.Location = new System.Drawing.Point(292, 118);
            this.WebPanel.Name = "WebPanel";
            this.WebPanel.Size = new System.Drawing.Size(950, 702);
            this.WebPanel.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1254, 832);
            this.Controls.Add(this.WebPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.LeftPanel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Fonts Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.LeftPanel.ResumeLayout(false);
            this.LeftPanel.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.WebPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
    }
}
