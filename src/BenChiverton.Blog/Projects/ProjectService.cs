using System.Collections.Generic;
using BenChiverton.Blog.Markdown;

namespace BenChiverton.Blog.Projects;

public interface IProjectService
{
    IReadOnlyDictionary<string, ProjectDetails> GetProjects();
    bool TryGetProjectDetails(string projectId, out ProjectDetails projectDetails);
}

public class ProjectService : IProjectService
{
    private readonly Dictionary<string, ProjectDetails> _projects = new()
    {
        {
            "GingerbreadAI",
            new ProjectDetails(
                "Gingerbread AI",
                "Neural network libraries written from scratch in C#. Includes implementation of dense and convolutional neural networks.",
                new MarkdownPage("benchiverton", "GingerbreadAI", "main", "README.md")
            )
        },
        {
            "TestContainers",
            new ProjectDetails(
                "Integration testing with testcontainers",
                "Example .NET integration tests using testcontainers to set up infrastructure on the fly.",
                new MarkdownPage("benchiverton", "DotNet.IntegrationTesting", "main", "README.md")
            )
        },
        {
            "TweetVisualiser",
            new ProjectDetails(
                "Tweet Visualiser",
                "Blazor application that streams and visualises live tweets. Uses CosmosDB change feeds to support multiple data processors.",
                new MarkdownPage("benchiverton", "TweetVisualiser", "main", "README.md")
            )
        },
        {
            "protseqspark",
            new ProjectDetails(
                "Protein Sequences Spark Library",
                "Python libraries written to read and process files containing protein sequence alignment data. Currently supports BAM files.",
                new MarkdownPage("benchiverton", "protseqspark", "master", "README.md")
            )
        },
        {
            "imfpredict",
            new ProjectDetails(
                "Predicting currency performance",
                "Python project analysing & predicting currency performance using data from International Monetary Fund (IMF).",
                new MarkdownPage("benchiverton", "imfpredict", "main", "README.md")
            )
        },
        {
            "Blog",
            new ProjectDetails(
                "This Blog!",
                "Details about this website.",
                new MarkdownPage("benchiverton", "Blog", "main", "README.md")
            )
        },
        {
            "BeerCountdown",
            new ProjectDetails(
                "Beer Countdown",
                "Blazor app deployed to GitHub Pages that counted down the time left before we could have a drink with our friends during lockdown.",
                new MarkdownPage("benchiverton", "BeerCountdown", "main", "README.md")
            )
        },
        {
            "WarwickHack2017",
            new ProjectDetails(
                "WarwickHACK 2017 project",
                "Java application written during WarwickHACK 2017. Winner of the creative concept award.",
                new MarkdownPage("benchiverton", "WarwickHack-Entry-2017", "master", "README.md")
            )
        },
        {
            "P5Projects",
            new ProjectDetails(
                "P5.js Projects",
                "Some scripts using P5.js which create some interesting visuals. This is how I originally got into coding!",
                new MarkdownPage("benchiverton", "P5-Projects", "master", "README.md")
            )
        },
    };

    public IReadOnlyDictionary<string, ProjectDetails> GetProjects() => _projects;

    public bool TryGetProjectDetails(string projectId, out ProjectDetails projectDetails) => _projects.TryGetValue(projectId, out projectDetails);
}
