namespace HtmlBuilder.Sections
{
    public interface ISection
    {
        string GenerateTextBody();
        string GenerateHtmlBody();
    }
}
