using BenChiverton.Blog.Markdown;

namespace BenChiverton.Blog.Projects;

public record ProjectDetails(
    string Name,
    string Description,
    MarkdownPage MarkdownPage
)
{
    public string ProjectUrl => $"https://github.com/{MarkdownPage.Organisation}/{MarkdownPage.Repository}";
}
