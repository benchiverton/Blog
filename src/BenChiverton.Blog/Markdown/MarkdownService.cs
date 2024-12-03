using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BenChiverton.Blog.Markdown;

public interface IMarkdownService
{
    Task<string> GetMarkdown(MarkdownPage markdownPage);
    Task<DateTime> GetPublishedDate(MarkdownPage markdownPage);
}

public class MarkdownService : IMarkdownService
{
    private readonly HttpClient _httpClient;

    public MarkdownService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetMarkdown(MarkdownPage markdownPage)
    {
        var documentUrl =
            $"https://raw.githubusercontent.com/{markdownPage.Organisation}/{markdownPage.Repository}/{markdownPage.Branch}/{markdownPage.FileLocation}";
        var contentHttpResponse = await _httpClient.GetAsync(documentUrl);
        var content = await contentHttpResponse.Content.ReadAsStringAsync();

        var documentLocation = documentUrl[..documentUrl.LastIndexOf("/")];
        return Regex.Replace(content, @"\]\((?!https)", $"]({documentLocation}/");
    }

    public async Task<DateTime> GetPublishedDate(MarkdownPage markdownPage)
    {
        var commitsUrl =
            $"https://api.github.com/repos/{markdownPage.Organisation}/{markdownPage.Repository}/commits?path={HttpUtility.UrlEncode(markdownPage.FileLocation)}&page=1&per_page=10";
        var commitsHttpResponse = await _httpClient.GetAsync(commitsUrl);

        var commits =
            JsonSerializer.Deserialize<List<CommitsResponseDto>>(await commitsHttpResponse.Content.ReadAsStreamAsync());
        return commits.Min(c => c.commit.author.date);
    }

    private class CommitsResponseDto
    {
        public CommitsResponseCommitDto commit { get; set; }
    }

    private class CommitsResponseCommitDto
    {
        public CommitsResponseAuthorDto author { get; set; }
    }

    private class CommitsResponseAuthorDto
    {
        public DateTime date { get; set; }
    }
}
