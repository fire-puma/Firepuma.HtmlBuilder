namespace Firepuma.HtmlBuilder.Sections
{
    public interface ISection
    {
        string GenerateTextBody();
        string GenerateHtmlBody();
    }
}
