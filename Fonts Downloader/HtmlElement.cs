using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fonts_Downloader
{
    public abstract class HtmlElement
    {
        public string Class { get; set; }
        public string Style { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> Children { get; set; } = [];
        public abstract string RenderElement();
    }

    public class Div : HtmlElement
    {
        public override string RenderElement()
        {
            var childrenHtml = string.Join("", Children.Select(c => c.RenderElement()));
            return $"<div class='{Class}'>{childrenHtml}</div>";
        }
    }

    public class Paragraph : HtmlElement
    {

        public override string RenderElement()
        {
            return $"<p  class='{Class}'>{Text}</p>";
        }
    }
    public class Header : HtmlElement
    {
        public int Level { get; }

        public Header(int level)
        {
            if (level < 1 || level > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(level), "Header level must be between 1 and 6.");
            }
            Level = level;
        }
        public override string RenderElement()
        {
            return $"<h{Level} style='{Style}' class='{Class}'>{Text}</h{Level}>";
        }
    }

    public class Aanker : HtmlElement
    {
        public string Href { get; set; }

        public override string RenderElement()
        {
            return $"<a href='{Href}' class='{Class}'>{Text}</a>";
        }
    }


    public class CssStyle
    {
        public string Selector { get; set; }
        public Dictionary<string, Dictionary<string, string>> Properties { get; set; } = [];

        public string Render()
        {
            var result = new StringBuilder();
            foreach (var style in Properties)
            {
                var properties = string.Join(";\n", style.Value.Select(p => $"{p.Key}: {p.Value}"));
                result.AppendLine($"{style.Key} {{\n{properties}\n}}");
            }
            return result.ToString();
        }
    }
}