using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class CssFile
    {
        private readonly Dictionary<string, string> FontFileStyles = new Dictionary<string, string>
        {
            { "100", "Thin" },
            { "200", "ExtraLight" },
            { "300", "Light" },
            { "400", "Regular" },
            { "500", "Medium" },
            { "600", "SemiBold" },
            { "700", "Bold" },
            { "800", "ExtraBold" },
            { "900", "Black" },
        };

        private List<string> _Styles = new List<string>();
        public List<string> Styles => _Styles;

        private List<string> _FontWeight = new List<string>();
        public List<string> FontWeight => _FontWeight;
        public void CreateCSS(CheckedListBox SizeAndStyle, List<string> SubSet, string FolderName, string FontName)
        {
            List<string> Css = new List<string>();

            for (int i = 0; i < SizeAndStyle.CheckedItems.Count; i++)
            {
                string fontStyle = SizeAndStyle.CheckedItems[i].ToString().Contains("italic") ? "italic" : "normal";
                _Styles.Add(fontStyle);
                 
                string fontWeight = SizeAndStyle.CheckedItems[i].ToString().Replace("italic", "");
                _FontWeight.Add(fontWeight);
                if (!string.IsNullOrWhiteSpace(fontWeight))
                {
                    string fontFileStyle = FontFileStyles.ContainsKey(fontWeight) ? FontFileStyles[fontWeight] : "Regular";

                    foreach (var sub in SubSet)
                    {
                        string css = $"/*{sub}*/" +
                                     $"\n@font-face {{\nfont-family: '{FontName}';\nfont-style: {fontStyle};\nfont-weight: {fontWeight};\nfont-stretch: 100%;" +
                                     $"\nsrc: url('{FontName.Replace(" ", "")}-{char.ToUpper(fontStyle[0]) + fontStyle.Substring(1)}-{fontFileStyle}.ttf')\n}}";
                        Css.Add(css);
                    }
                }
            }

            if (Css.Any())
            {
                string fontFolder = $"{FolderName}\\{FontName.Replace(" ", "")}";
                Directory.CreateDirectory(fontFolder);

                using (StreamWriter writer = new StreamWriter(Path.Combine(fontFolder, $"{FontName.Replace(" ", "")}.css"), false))
                {
                    foreach (var str in Css)
                    {
                        writer.WriteLine(str);
                    }
                }
            }
        }
    }
}
