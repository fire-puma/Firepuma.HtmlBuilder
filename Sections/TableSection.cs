using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Firepuma.HtmlBuilder.Sections
{
    public class TableSection : ISection
    {
        public string TableCaption { get; }

        public IEnumerable<string> Headers { get; }
        public IEnumerable<IEnumerable<string>> Rows { get; }

        public TableSection(string tableCaption, IEnumerable<string> headers, IEnumerable<IEnumerable<string>> rows)
        {
            TableCaption = tableCaption;
            Headers = headers;
            Rows = rows;
        }

        public string GenerateTextBody()
        {
            var sb = new StringBuilder();

            sb.AppendLine(TableCaption);
            sb.AppendLine(string.Join("", Enumerable.Repeat("=", TableCaption.Length)));

            var headerLine = string.Join(", ", Headers);
            sb.AppendLine(string.Join("", Enumerable.Repeat("-", headerLine.Length)));
            sb.AppendLine(headerLine);

            foreach (var rowCells in Rows)
            {
                sb.AppendLine(string.Join(", ", rowCells));
            }

            return sb.ToString();
        }

        public string GenerateHtmlBody()
        {
            var sb = new StringBuilder();

            sb.Append($"<table style='border-collapse:collapse; width:100%;' cellpadding='5'>");

            sb.Append($"<caption style='border:solid 1px #ddd; border-bottom:none; font-size:1.5em; background-color: gray; color: white;'> {TableCaption} </caption>");
            sb.Append($"<thead>");
            sb.Append($"<tr>");
            foreach (var header in Headers)
            {
                sb.Append($"<td style='border:solid 1px #ddd;'> {header} </td>");
            }
            sb.Append($"</tr>");
            sb.Append($"</thead>");

            int rowCount = 0;
            foreach (var rowCells in Rows)
            {
                var rowStyles = "";
                if (rowCount++ % 2 != 0)
                {
                    rowStyles += "background-color: rgba(0, 0, 0, 0.05);";
                }
                sb.Append($"<tr style='{rowStyles}'>");
                foreach (var cell in rowCells)
                {
                    sb.Append($"<td style='border:solid 1px #ddd;'> {cell} </td>");
                }
                sb.Append($"</tr>");
            }

            sb.Append($"</table>");

            return sb.ToString();
        }
    }
}
