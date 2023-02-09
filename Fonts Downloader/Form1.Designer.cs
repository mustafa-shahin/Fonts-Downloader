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
            this.SizeAndStyle = new System.Windows.Forms.CheckedListBox();
            this.SelectFolder = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.FontBox1 = new System.Windows.Forms.ComboBox();
            this.SelectedFont = new System.Windows.Forms.Label();
            this.CopyFont = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SizeAndStyle
            // 
            this.SizeAndStyle.CheckOnClick = true;
            this.SizeAndStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SizeAndStyle.FormattingEnabled = true;
            this.SizeAndStyle.Location = new System.Drawing.Point(-1, 121);
            this.SizeAndStyle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SizeAndStyle.Name = "SizeAndStyle";
            this.SizeAndStyle.Size = new System.Drawing.Size(241, 242);
            this.SizeAndStyle.TabIndex = 15;
            // 
            // SelectFolder
            // 
            this.SelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectFolder.Location = new System.Drawing.Point(0, 10);
            this.SelectFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(119, 46);
            this.SelectFolder.TabIndex = 30;
            this.SelectFolder.Text = "Select Folder";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(125, 10);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(663, 45);
            this.textBox1.TabIndex = 31;
            // 
            // FontBox1
            // 
            this.FontBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FontBox1.FormattingEnabled = true;
            this.FontBox1.Location = new System.Drawing.Point(-1, 64);
            this.FontBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.FontBox1.Name = "FontBox1";
            this.FontBox1.Size = new System.Drawing.Size(242, 28);
            this.FontBox1.TabIndex = 32;
            this.FontBox1.SelectionChangeCommitted += new System.EventHandler(this.FontBox1_SelectionChangeCommitted);
            // 
            // SelectedFont
            // 
            this.SelectedFont.AutoSize = true;
            this.SelectedFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFont.Location = new System.Drawing.Point(-5, 94);
            this.SelectedFont.Name = "SelectedFont";
            this.SelectedFont.Size = new System.Drawing.Size(51, 25);
            this.SelectedFont.TabIndex = 33;
            this.SelectedFont.Text = "Font";
            // 
            // CopyFont
            // 
            this.CopyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CopyFont.Location = new System.Drawing.Point(-1, 374);
            this.CopyFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CopyFont.Name = "CopyFont";
            this.CopyFont.Size = new System.Drawing.Size(241, 43);
            this.CopyFont.TabIndex = 34;
            this.CopyFont.Text = "Download Font";
            this.CopyFont.UseVisualStyleBackColor = true;
            this.CopyFont.Click += new System.EventHandler(this.CopyFont_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 428);
            this.Controls.Add(this.CopyFont);
            this.Controls.Add(this.SelectedFont);
            this.Controls.Add(this.FontBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SelectFolder);
            this.Controls.Add(this.SizeAndStyle);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Fonts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CheckedListBox SizeAndStyle;
        private Button SelectFolder;
        private TextBox textBox1;
        private ComboBox FontBox1;
        private Label SelectedFont;
        private Button CopyFont;
    }
}
