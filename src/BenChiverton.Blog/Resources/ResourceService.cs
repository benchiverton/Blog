using System.Collections.Generic;
using System.Linq;

namespace BenChiverton.Blog.Resources;

public interface IResourceService
{
    IReadOnlyDictionary<string, ResourceDetails> GetResources(string filter);
    bool TryGetResourceDetails(string projectId, out ResourceDetails projectDetails);
}

public class ResourceService : IResourceService
{
    private readonly Dictionary<string, ResourceDetails> _resources = new()
    {
        {
            "trapeziumruleexercise",
            new ResourceDetails(
                "Trapezium rule exercise",
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/TsIZcnLm2" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/sD2UgZ210" },
                },
                new List<string> { "exercise", "JavaScript", "p5.js", }
            )
        },
        {
            "kinematicsexercise",
            new ResourceDetails(
                "Kinematics exercise",
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/MlOkyPOCn" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/yzg0EGjCJ" },
                },
                new List<string> { "exercise", "JavaScript", "p5.js", }
            )
        },
        {
            "floodfillexercise",
            new ResourceDetails(
                "Flood fill exercise",
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/OXtuzLfV6" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/7Vv1fnlvj" },
                },
                new List<string> { "exercise", "JavaScript", "p5.js", }
            )
        },
    };

    public IReadOnlyDictionary<string, ResourceDetails> GetResources(string filter) => _resources.Where(r =>
        r.Value.Name.Contains(filter, System.StringComparison.OrdinalIgnoreCase)
        || r.Value.Tags.Any(t => t.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
    ).ToDictionary(x => x.Key, x => x.Value);

    public bool TryGetResourceDetails(string resourceId, out ResourceDetails resourceDetails) => _resources.TryGetValue(resourceId, out resourceDetails);
}
