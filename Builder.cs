using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firepuma.HtmlBuilder.Sections;

namespace Firepuma.HtmlBuilder
{
    public class Builder : IBuilder
    {
        private readonly List<ISection> _sections;

        public Builder()
        {
            _sections = new List<ISection>();
        }

        public IBuilder AddSection(ISection section)
        {
            _sections.Add(section);
            return this;
        }

        public IBuilder AddTable(TableSection tableSection)
        {
            _sections.Add(tableSection);
            return this;
        }

        public IBuilder AddError(ErrorSection error)
        {
            _sections.Add(error);
            return this;
        }

        public string ToHtml()
        {
            var sb = new StringBuilder();

            foreach (var section in _sections)
            {
                sb.AppendLine("<p>");
                sb.AppendLine(section.GenerateHtmlBody());
                sb.AppendLine("</p>");

                sb.AppendLine("<p> &nbsp; </p>");
            }

            return sb.ToString();
        }

        public async Task<string> ToText()
        {
            var sb = new StringBuilder();

            foreach (var section in _sections)
            {
                sb.AppendLine(section.GenerateTextBody());

                sb.AppendLine("--------------------------------------------------------------------------------------");
            }

            return await Task.FromResult(sb.ToString());
        }
    }
}