using System.Collections.Generic;

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
                "https://github.com/benchiverton/GingerbreadAI",
                "https://raw.githubusercontent.com/benchiverton/GingerbreadAI/main/README.md"
            )
        },
        {
            "TweetVisualiser",
            new ProjectDetails(
                "Tweet Visualiser",
                "Blazor application that streams and visualises live tweets. Uses CosmosDB change feeds to support multiple data processors.",
                "https://github.com/benchiverton/TweetVisualiser",
                "https://raw.githubusercontent.com/benchiverton/TweetVisualiser/main/README.md"
            )
        },
        {
            "OutboxPattern",
            new ProjectDetails(
                "Outbox Pattern",
                "Dotnet applications that help visualise the outboc pattern by implementing it in several ways. Usese Web API's and NServiceBus.",
                "https://github.com/benchiverton/OutboxPatternDemo",
                "https://raw.githubusercontent.com/benchiverton/OutboxPatternDemo/main/README.md"
            )
        },
        {
            "OnlineStore",
            new ProjectDetails(
                "Online Store",
                "Blazor WebAssembly application simulating an online store. Deployed to Azure using Github Actions and Terraform. Has a complete CI/CD pipeline.",
                "https://github.com/benchiverton/OnlineStore",
                "https://raw.githubusercontent.com/benchiverton/OnlineStore/main/README.md"
            )
        },
        {
            "protseqspark",
            new ProjectDetails(
                "Protein Sequences Spark Library",
                "Python libraries written to read and process files containing protein sequence alignment data. Currently supports BAM files.",
                "https://github.com/benchiverton/protseqspark",
                "https://raw.githubusercontent.com/benchiverton/protseqspark/master/README.md"
            )
        },
        {
            "imfpredict",
            new ProjectDetails(
                "Protein Sequences Spark Library",
                "Python project analysing & predicting currency performance using data from International Monetary Fund (IMF).",
                "https://github.com/benchiverton/imfpredict",
                "https://raw.githubusercontent.com/benchiverton/imfpredict/main/README.md"
            )
        },
        {
            "Blog",
            new ProjectDetails(
                "This Blog!",
                "Details about this website.",
                "https://github.com/benchiverton/Blog",
                "https://raw.githubusercontent.com/benchiverton/Blog/main/README.md"
            )
        },
        {
            "BeerCountdown",
            new ProjectDetails(
                "Beer Countdown",
                "Blazor app deployed to GitHub Pages that counted down the time left before we could have a drink with our friends during lockdown.",
                "https://github.com/benchiverton/BeerCountdown",
                "https://raw.githubusercontent.com/benchiverton/BeerCountdown/main/README.md"
            )
        },
        {
            "WarwickHack2017",
            new ProjectDetails(
                "WarwickHACK 2017 project",
                "Java application written during WarwickHACK 2017. Winner of the creative concept award.",
                "https://github.com/benchiverton/WarwickHack-Entry-2017",
                "https://raw.githubusercontent.com/benchiverton/WarwickHack-Entry-2017/master/README.md"
            )
        },
        {
            "P5Projects",
            new ProjectDetails(
                "P5.js Projects",
                "Some scripts using P5.js which create some interesting visuals. This is how I originally got into coding!",
                "https://github.com/benchiverton/P5-Projects",
                "https://raw.githubusercontent.com/benchiverton/P5-Projects/master/README.md"
            )
        },
    };

    public IReadOnlyDictionary<string, ProjectDetails> GetProjects() => _projects;

    public bool TryGetProjectDetails(string projectId, out ProjectDetails projectDetails) => _projects.TryGetValue(projectId, out projectDetails);
}
