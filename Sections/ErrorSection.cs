namespace Firepuma.HtmlBuilder.Sections
{
    public class ErrorSection : ISection
    {
        public string Title { get; }
        public string ErrorMessage { get; }

        public ErrorSection(string errorMessage)
        {
            Title = "ERROR";
            ErrorMessage = errorMessage;
        }

        public string GenerateTextBody()
        {
            return ErrorMessage;
        }

        public string GenerateHtmlBody()
        {
            return "<p style='color:red; font-weight:bold'>" + ErrorMessage + "</p>";
        }
    }
}
