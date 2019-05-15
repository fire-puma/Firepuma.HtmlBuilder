using System.Threading.Tasks;
using HtmlBuilder.Sections;

namespace HtmlBuilder
{
    public interface IBuilder
    {
        IBuilder AddTable(TableSection tableSection);
        IBuilder AddError(ErrorSection error);
        string ToHtml();
        Task<string> ToText();
    }
}