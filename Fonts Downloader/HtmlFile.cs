using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fonts_Downloader
{
    internal class HtmlFile
    {
        private const string Path = @"C:\FontDownloader";
        public static void DefaultHtml()
        {
            string Text = Api.IsInternetAvailable()
                ? "<h3>The program will create a folder named FontDownloader on the C drive to render the fonts.</h3>" +
                "<h3 style=\"color:#9b2b22;\"> Please select whether you want TTF or WOFF2 files by checking one of the boxes above</h3>"
                : "<h1 style=\"color:#9b2b22;\">Check your internet connection</h1>";
            if(!Directory.Exists(Path))
                Directory.CreateDirectory(Path);

            string DefaultHtml = $@"
                <head>
                    <link href=""https://fonts.googleapis.com/css2?family=Roboto:wght@900&display=swap"" rel=""stylesheet"">
                    <style>
                        body {{
                            font-family: 'Roboto', sans-serif;
                            color: white !important;
                            text-align: center !important;
                        }}
                        h1 {{
                            font-weight: 700 !important;
                        }}
                    </style>
                </head>
                <body>
                    <h1>Fonts Downloader </h1>
                    {Text}
                </body>";

            using StreamWriter Writer = new($"{Path}\\index.html", false);
            Writer.WriteLine(DefaultHtml);
        }

        public static void CreateHtml(string SelectedFont, List<string> Variants)
        {
            var FontFileStyles = new Dictionary<string, string>
            {
                { "100", "Thin" }, { "200", "ExtraLight" },
                { "300", "Light" },  { "400", "Regular" },
                { "500", "Medium" }, { "600", "SemiBold" },
                { "700", "Bold" }, { "800", "ExtraBold" },
                { "900", "Black" },
            };
            List<string> WgtItalic = new();
            List<string> WgtNormal = new();
            foreach (var variant in Variants)
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
            string PTagItalic, PTagNormal, ParagrapphItalic, ParagrapphNormal, Lorem = "Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua";
            string Italics = string.Join(";", WgtItalic);
            string Normals = string.Join(";", WgtNormal);
            string GoogleFontLinkItalics = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont}:ital,wght@{Italics}&display=swap\" rel=\"stylesheet\">";
            string GoogleFontLinkItalicsNormals = $"<link href=\"https://fonts.googleapis.com/css2?family={SelectedFont}:wght@{Normals}&display=swap\" rel=\"stylesheet\">";
            string FontFamliyStyle = $"font-family: '{SelectedFont}', sans-serif;";
            string BodyStyle = "body{\n" + FontFamliyStyle + "\n" + "color: white;" + "\n" + "}";
            List<string> PTagCSS = new();
            List<string> PTags = new();
            List<string> H1Tags = new();
            List<string> H1TagsCSS = new();
            string H1Italic, H1Normal, H1TagItalic, H1TagNormal;
            if (WgtItalic.Any() && WgtItalic != null)
            {
                foreach (string wgt in WgtItalic)
                {
                    var FontFileStyle = FontFileStyles.GetValueOrDefault(wgt.Replace("1,", ""));
                    //P tag italic  styling
                    PTagItalic = "\np." + "size" + $"{wgt.Replace("1,", "")}italic" + "{\n" + "font-family:" + $"'{SelectedFont}';\n" + "font-style: italic;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTagCSS.Add(PTagItalic);

                    //P tag italic tag html
                    ParagrapphItalic = $"<p class = 'size{wgt.Replace("1,", "")}italic'>" + $"{Lorem}</p>";
                    PTags.Add(ParagrapphItalic);

                    //H1 tag italic styling
                    H1Italic = "\nh1." + "size" + $"{wgt.Replace("1,", "")}italic" + "{\n" + "font-family:" + $"'{SelectedFont}';\n" + "font-style: italic;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    H1TagsCSS.Add(H1Italic);

                    //H1 tag italic html
                    H1TagItalic = $"<h1 class = 'size{wgt.Replace("1,", "")}italic'>" + $"{SelectedFont}" + " " + $"{wgt.Replace("1,", "")} - {FontFileStyle} Italic  " + "</h1>";
                    H1Tags.Add(H1TagItalic);

                }
            }
            if (WgtNormal.Any() && WgtNormal != null)
            {
                foreach (string wgt in WgtNormal)
                {
                    var FontFileStyle = FontFileStyles.GetValueOrDefault(wgt.Replace("1,", ""));
                    //P tag normal styling
                    PTagNormal = "\np." + "size" + $"{wgt}normal" + "{\n" + "font-family:" + $"'{SelectedFont}';\n" + "font-style: normal;\n" + "font-weight:" + $"{wgt};" + "\r\nfont-stretch: 100%;" + "\n}";
                    PTagCSS.Add(PTagNormal);

                    //P tag normal html
                    ParagrapphNormal = $"<p class = 'size{wgt}normal'>" + $"{Lorem}</p>";
                    PTags.Add(ParagrapphNormal);

                    //H1 tag normal styling
                    H1Normal = "\nh1." + "size" + $"{wgt}normal" + "{\n" + "font-family:" + $"'{SelectedFont}';\n" + "font-style: normal;\n" + "font-weight:" + $"{wgt.Replace("1,", "")};" + "\r\nfont-stretch: 100%;" + "\n}";
                    H1TagsCSS.Add(H1Normal);

                    //H1 tag normal html
                    H1TagNormal = $"<h1 class = 'size{wgt}normal'>" + $"{SelectedFont}" + " " + $"{wgt.Replace("1,", "") } - {FontFileStyle} Normal " + "</h1>";
                    H1Tags.Add(H1TagNormal);
                }
            }

            using (StreamWriter Writer = new($"{Path}\\index.html", false))
            {
                Writer.WriteLine("<head>");
                if (!string.IsNullOrEmpty(Italics))
                {
                    Writer.WriteLine(GoogleFontLinkItalics);
                }
                if (!string.IsNullOrEmpty(Normals))
                {
                    Writer.WriteLine(GoogleFontLinkItalicsNormals);
                }
                Writer.WriteLine("</head>");
                Writer.WriteLine("<style>" + "\n" + BodyStyle);
                for (int i = 0; i < PTagCSS.Count; i++)
                {
                    Writer.WriteLine(PTagCSS[i]);
                    Writer.WriteLine(H1TagsCSS[i]);
                    if (i == PTagCSS.Count - 1)
                    {
                        Writer.WriteLine("</style>");
                    }
                }
                for (int i = 0; i < PTags.Count; i++)
                {
                    Writer.WriteLine("<body>");
                    Writer.WriteLine(H1Tags[i]);
                    Writer.WriteLine(PTags[i]);
                    if (i == PTags.Count - 1)
                    {
                        Writer.WriteLine("</body>");
                    }
                }
            }
            WgtItalic.Clear();
            WgtNormal.Clear();
        }
        public static void ShowError()
        {
            string Error = "<html><body>\n<h1 style=\"color:#9b2b22;text-align: center;\">Check yor API key </h1>\n</body>\n</html>";
            using StreamWriter Writer = new($"{Path}\\index.html", false);
            Writer.WriteLine(Error,false);
        }
    }
}

