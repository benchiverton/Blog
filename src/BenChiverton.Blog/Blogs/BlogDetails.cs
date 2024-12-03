using System;
using BenChiverton.Blog.Markdown;

namespace BenChiverton.Blog.Blogs;

public record BlogDetails(
    string Name,
    string Description,
    MarkdownPage MarkdownPage
)
{
    public DateTime? Published { get; set; } = null;
}
