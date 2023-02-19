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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FontBox1 = new System.Windows.Forms.ComboBox();
            this.SelectedFont = new System.Windows.Forms.Label();
            this.CopyFont = new System.Windows.Forms.Button();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // SizeAndStyle
            // 
            this.SizeAndStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(98)))), ((int)(((byte)(101)))));
            this.SizeAndStyle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SizeAndStyle.CheckOnClick = true;
            this.SizeAndStyle.ForeColor = System.Drawing.Color.White;
            this.SizeAndStyle.FormattingEnabled = true;
            this.SizeAndStyle.Location = new System.Drawing.Point(20, 82);
            this.SizeAndStyle.Margin = new System.Windows.Forms.Padding(3, 3, 3, 2);
            this.SizeAndStyle.Name = "SizeAndStyle";
            this.SizeAndStyle.Size = new System.Drawing.Size(237, 357);
            this.SizeAndStyle.TabIndex = 15;
            // 
            // SelectFolder
            // 
            this.SelectFolder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.SelectFolder.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFolder.ForeColor = System.Drawing.Color.White;
            this.SelectFolder.Location = new System.Drawing.Point(131, 28);
            this.SelectFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(121, 32);
            this.SelectFolder.TabIndex = 30;
            this.SelectFolder.Text = "Select Folder";
            this.SelectFolder.UseVisualStyleBackColor = false;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(272, 28);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(528, 32);
            this.textBox1.TabIndex = 31;
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
            this.CopyFont.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.CopyFont.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(114)))), ((int)(((byte)(66)))));
            this.CopyFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyFont.ForeColor = System.Drawing.Color.White;
            this.CopyFont.Location = new System.Drawing.Point(20, 460);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.panel1.Controls.Add(this.CopyFont);
            this.panel1.Controls.Add(this.SelectedFont);
            this.panel1.Controls.Add(this.SizeAndStyle);
            this.panel1.Controls.Add(this.FontBox1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(274, 808);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.SelectFolder);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(292, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(950, 100);
            this.panel2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(186, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Api Key";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(211)))), ((int)(((byte)(200)))));
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(272, 66);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(528, 32);
            this.textBox2.TabIndex = 32;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(62)))), ((int)(((byte)(79)))));
            this.panel3.Controls.Add(this.webView21);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(292, 118);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(950, 702);
            this.panel3.TabIndex = 38;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(1254, 832);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Fonts";
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private CheckedListBox SizeAndStyle;
        private Button SelectFolder;
        private TextBox textBox1;
        private ComboBox FontBox1;
        private Label SelectedFont;
        private Button CopyFont;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private TextBox textBox2;
    }
}
