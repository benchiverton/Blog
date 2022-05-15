using System.Text.RegularExpressions;

namespace BenChiverton.Blog.Markdown;

public static class MarkdownExtensions
{
    public static string ReplaceRelativeImageLocations(this string readmeContent, string documentUrl)
    {
        var documentLocation = documentUrl[..documentUrl.LastIndexOf("/")];
        return Regex.Replace(readmeContent, @"\]\((?!https)", $"]({documentLocation}/");
    }
}
