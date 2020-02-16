using System.Threading.Tasks;
using Firepuma.HtmlBuilder.Sections;

namespace Firepuma.HtmlBuilder
{
    public interface IBuilder
    {
        IBuilder AddTable(TableSection tableSection);
        IBuilder AddError(ErrorSection error);
        string ToHtml();
        Task<string> ToText();
    }
}