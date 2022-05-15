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
