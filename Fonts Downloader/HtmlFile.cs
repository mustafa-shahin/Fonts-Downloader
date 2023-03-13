using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fonts_Downloader
{
    internal class HtmlFile
    {
        private string Path = @"C:\FontDownlaoder";
        public void DefaultHtml()
        {
            System.IO.Directory.CreateDirectory(Path);
            string DefaultHtml = "<head>\r\n" +
                "<link href=\"https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap\" rel=\"stylesheet\">\r\n" +
                "</head>\r\n" +
                "<style>\r\n" +
                "body{\r\n" +
                "font-family: 'Roboto', sans-serif;\r\n" +
                "color:white!important;\r\n" +
                "text-align: center !important;\r\n}\r\n\r\n" +
                "h1{\r\nfont-weight: 700 !important;\r\n}\r\n" +
                "</style>\r\n" +
                "<body>\r\n" +
                "<h1>Fonts Downloader </h1>\r\n" +
                "</body>";
            using (StreamWriter writer = new StreamWriter($"{Path}\\index.html", false))
            {
                writer.WriteLine(DefaultHtml);
            }
        }

        public void CreateHtml(Label SelectedFont, CheckedListBox SizeAndStyle)
        {
            List<string> WgtItalic = new List<string>();
            List<string> WgtNormal = new List<string>();
            foreach (var variant in SizeAndStyle.Items)
            {
                if (!variant.ToString().Contains("italic"))
                {
                    WgtNormal.Add(variant.ToString());

                }
                else
                {
                    WgtItalic.Add("1," + variant.ToString().Replace("italic", ""));
                }
            }
            string FontColor = "color: white;";
            string PTagItalic, PTagNormal, ParagrapphItalic, ParagrapphNormal, Lorem = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
            string Italics = string.Join(";", WgtItalic);
            string Normals = string.Join(";", WgtNormal);
            string GoogleFontLinkItalics = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont.Text}:ital,wght@{Italics}&display=swap\" rel=\"stylesheet\">";
            string GoogleFontLinkItalicsNormals = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont.Text}:wght@{Normals}&display=swap\" rel=\"stylesheet\">";
            string FontFamliyStyle = $"font-family: '{SelectedFont.Text}', sans-serif;";
            string BodyStyle = "body{\n" + FontFamliyStyle + "\n" + FontColor + "\n" + "}";
            string BodyTagStart = "<body>" + "\n";
            List<string> PTagCSS = new List<string>();
            List<string> PTags = new List<string>();
            List<string> H1Tags = new List<string>();
            List<string> H1TagsCSS = new List<string>();
            string StyleTagEnd = "</style>";
            string HeadStart = "<head>";
            string HeadEnd = "</head>";
            string StyleTagStart = "<style>";
            string H1Italic, H1Normal, H1TagItalic, H1TagNormal;
            string BodyTagEnd = "</body>";

            if (WgtItalic.Any())
            {
                foreach (string wgt in WgtItalic)
                {
                    //P tag italic  styling
                    PTagItalic = "\np." + "size" + $"{wgt.Replace("1,", "")}italic" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: italic;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTagCSS.Add(PTagItalic);

                    //P tag italic tag html
                    ParagrapphItalic = $"<p class = 'size{wgt.Replace("1,", "")}italic'>" + $"{Lorem}</p>";
                    PTags.Add(ParagrapphItalic);

                    //H1 tag italic styling
                    H1Italic = "\nh1." + "size" + $"{wgt.Replace("1,", "")}italic" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: italic;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    H1TagsCSS.Add(H1Italic);

                    //H1 tag italic html
                    H1TagItalic = $"<h1 class = 'size{wgt.Replace("1,", "")}italic'>" + $"{SelectedFont.Text}" + " " + $"{wgt.Replace("1,", "")} Italic" + "</h1>";
                    H1Tags.Add(H1TagItalic);

                }
            }
            if (WgtNormal.Any())
            {
                foreach (string wgt in WgtNormal)
                {
                    //P tag normal styling
                    PTagNormal = "\np." + "size" + $"{wgt}normal" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: normal;\n" + "font-weight:" + $"{wgt};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTagCSS.Add(PTagNormal);

                    //P tag normal html
                    ParagrapphNormal = $"<p class = 'size{wgt}normal'>" + $"{Lorem}</p>";
                    PTags.Add(ParagrapphNormal);

                    //H1 tag normal styling
                    H1Normal = "\nh1." + "size" + $"{wgt}normal" + "{\n" + "font-family:" + $"'{SelectedFont.Text}';\n" + "font-style: normal;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    H1TagsCSS.Add(H1Normal);

                    //H1 tag normal html
                    H1TagNormal = $"<h1 class = 'size{wgt}normal'>" + $"{SelectedFont.Text}" + " " + $"{wgt.Replace("1,", "")} Normal" + "</h1>";
                    H1Tags.Add(H1TagNormal);
                }
            }

            using (StreamWriter writer = new StreamWriter($"{Path}\\index.html", false))

            {
                for (int i = 0; i < PTagCSS.Count; i++)
                {
                    if (i == 0)
                    {
                        writer.WriteLine(HeadStart);
                        if (!string.IsNullOrEmpty(Italics))
                        {
                            writer.WriteLine(GoogleFontLinkItalics);
                        }
                        if (!string.IsNullOrEmpty(Normals))
                        {
                            writer.WriteLine(GoogleFontLinkItalicsNormals);
                        }
                        writer.WriteLine(HeadEnd);

                    }
                    if (i == 0)
                        writer.WriteLine(StyleTagStart + "\n" + BodyStyle);

                    writer.WriteLine(PTagCSS[i]);
                    writer.WriteLine(H1TagsCSS[i]);
                    if (i == PTagCSS.Count - 1)
                    {
                        writer.WriteLine(StyleTagEnd + "\n" + BodyTagStart);
                    }
                }
                for (int i = 0; i < PTags.Count; i++)
                {
                    writer.WriteLine(H1Tags[i]);
                    writer.WriteLine(PTags[i]);
                    if (i == PTags.Count - 1)
                    {
                        writer.WriteLine(BodyTagEnd);
                    }
                }
            }
            WgtItalic.Clear();
            WgtNormal.Clear();
        }
    }
}

