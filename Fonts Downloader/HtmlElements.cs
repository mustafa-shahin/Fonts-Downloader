using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fonts_Downloader
{
    public abstract class HtmlElements
    {
        public string Class { get; set; }
        public string Style { get; set; }
        public string Text { get; set; }
        public List<HtmlElements> Children { get; set; } = [];

        protected string RenderAttributes()
        {
            var attributes = new StringBuilder();
            if (!string.IsNullOrEmpty(Class))
                attributes.Append($" class='{Class}'");

            if (!string.IsNullOrEmpty(Style))
                attributes.Append($" style='{Style}'");

            return attributes.ToString();
        }

        public abstract string RenderElement();
    }

    public class Div : HtmlElements
    {
        public string Id { get; set; }

        public override string RenderElement()
        {
            var attributes = new StringBuilder(RenderAttributes());
            if (!string.IsNullOrEmpty(Id))
                attributes.Append($" id='{Id}'");

            var childrenHtml = string.Join("", Children.Select(c => c.RenderElement()));
            return $"<div{attributes}>{childrenHtml}</div>";
        }
    }

    public class Paragraph : HtmlElements
    {
        public override string RenderElement()
        {
            return $"<p{RenderAttributes()}>{Text}</p>";
        }
    }

    public class Header : HtmlElements
    {
        private int _level;

        public int Level
        {
            get => _level;
            set
            {
                if (value < 1 || value > 6)
                    throw new ArgumentOutOfRangeException(nameof(Level), "Header level must be between 1 and 6.");
                _level = value;
            }
        }

        public Header(int level)
        {
            Level = level;
        }

        public override string RenderElement()
        {
            return $"<h{Level}{RenderAttributes()}>{Text}</h{Level}>";
        }
    }

    public class Anchor : HtmlElements
    {
        public string Href { get; set; }
        public string Target { get; set; }
        public string Rel { get; set; }

        public override string RenderElement()
        {
            if (string.IsNullOrEmpty(Href))
                throw new InvalidOperationException("Href cannot be null or empty for an anchor element.");

            var attributes = new StringBuilder(RenderAttributes());
            attributes.Append($" href='{Href}'");

            if (!string.IsNullOrEmpty(Target))
                attributes.Append($" target='{Target}'");

            if (!string.IsNullOrEmpty(Rel))
                attributes.Append($" rel='{Rel}'");

            return $"<a{attributes}>{Text}</a>";
        }
    }

    public class CssStyle
    {
        public Dictionary<string, Dictionary<string, string>> Properties { get; set; } = [];

        public string Render()
        {
            var result = new StringBuilder();
            foreach (var style in Properties)
            {
                var properties = string.Join(";\n", style.Value.Select(p => $"{p.Key}: {p.Value}"));
                result.AppendLine($"{style.Key} {{\n{properties};\n}}");
            }
            return result.ToString();
        }
    }
}