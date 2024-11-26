using System.Collections.Generic;

namespace BenChiverton.Blog.Blogs;

public interface IBlogService
{
    IReadOnlyDictionary<string, BlogDetails> GetBlogs();
    bool TryGetBlogDetails(string blogId, out BlogDetails blogDetails);
}

public class BlogService : IBlogService
{
    private readonly Dictionary<string, BlogDetails> _blogs = new()
    {
        {
            "AsyncApi",
            new BlogDetails(
                "Enhance your API's using async messaging.",
                "How to use asynchronous messaging concepts to create high performance API's, avoiding issues caused by synchronous RPC calls.",
                "https://raw.githubusercontent.com/benchiverton/AsyncApiDemo/refs/heads/main/docs/async-api-blog.md"
            )
        },
        {
            "OpenTelemetry",
            new BlogDetails(
                "Distributed monitoring in dotnet",
                "Implementing a distributed monitoring solution for a hobby project using OpenTelemetry and .NET Aspire.",
                "https://raw.githubusercontent.com/benchiverton/OnlineStore/main/docs/Telemetry/DistributedMonitoring.md"
            )
        },
        {
            "TestContainers",
            new BlogDetails(
                "Integration testing with testcontainers",
                "Without provisioning dedicated infrastructure, integration testing can be hard to get into the CICD pipeline. Testcontainers can help bridge this gap.",
                "https://raw.githubusercontent.com/benchiverton/DotNet.IntegrationTesting/main/docs/testing_with_testcontainers.md"
            )
        },
        {
            "InstallingDocker",
            new BlogDetails(
                "Installing Docker on Windows (without Docker Desktop!)",
                "I don't use Docker enough in my day to day to justify a Docker Desktop license - these are the steps I follow to install Docker onto WSL.",
                "https://raw.githubusercontent.com/benchiverton/DotNet.IntegrationTesting/main/docs/installing_docker_windows.md"
            )
        },
        {
            "ModellingNeurons",
            new BlogDetails(
                "Modelling Neurons",
                "Developing a model for an artificial neuron, and deriving its output formula from scratch.",
                "https://raw.githubusercontent.com/benchiverton/GingerbreadAI/main/docs/NerualNetwork/NeuralNetworks.md"
            )
        },
    };

    public IReadOnlyDictionary<string, BlogDetails> GetBlogs() => _blogs;

    public bool TryGetBlogDetails(string blogId, out BlogDetails blogDetails) => _blogs.TryGetValue(blogId, out blogDetails);
}
