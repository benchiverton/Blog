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
            "microsoftdocsdomainmodelling",
            new ResourceDetails(
                "Microsoft docs - domain modelling",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Domain analysis", "https://docs.microsoft.com/en-us/azure/architecture/microservices/model/domain-analysis" },
                    { "Identify microservice boundaries", "https://docs.microsoft.com/en-us/azure/architecture/microservices/model/microservice-boundaries" },
                },
                new List<string> { "Microsoft", "Architecture", "Domain" }
            )
        },
        {
            "microsoftdocsmicroservices",
            new ResourceDetails(
                "Microsoft docs - microservices",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Interservice communication", "https://docs.microsoft.com/en-us/azure/architecture/microservices/design/interservice-communication" },
                    { "API gateways", "https://docs.microsoft.com/en-us/azure/architecture/microservices/design/gateway" },
                    { "Design patterns", "https://docs.microsoft.com/en-us/azure/architecture/microservices/design/patterns" },
                    { "Migrate monolith to microservices", "https://docs.microsoft.com/en-us/azure/architecture/microservices/migrate-monolith" },
                },
                new List<string> { "Microsoft", "Architecture", "Microservices" }
            )
        },
        {
            "okrs",
            new ResourceDetails(
                "OKRs",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "How to Create Good OKRs 🎯", "https://refactoring.fm/p/how-to-create-good-okrs-" },
                },
                new List<string> { "OKRs", "Process" }
            )
        },
        {
            "powerpointtemplate",
            new ResourceDetails(
                "PowerPoint template",
                new Dictionary<string, string>
                {
                    {"PowerPoint_TEMPLATE.pptx", "BenChiverton.Blog.Resources.Downloads.powerpoint_template.template.pptx" }
                },
                new Dictionary<string, string>(),
                new List<string> { "PowerPoint" }
            )
        },
        {
            "evolutionofit",
            new ResourceDetails(
                "Evolution of IT",
                new Dictionary<string, string>
                {
                    {"Evolution_of_IT.pptx", "BenChiverton.Blog.Resources.Downloads.evolution_of_IT.evolution_of_IT.pptx" }
                },
                new Dictionary<string, string>(),
                new List<string> { "PowerPoint" }
            )
        },
        {
            "trapeziumruleexercise",
            new ResourceDetails(
                "Trapezium rule exercise",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/TsIZcnLm2" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/sD2UgZ210" },
                },
                new List<string> { "JavaScript", "p5.js", }
            )
        },
        {
            "kinematicsexercise",
            new ResourceDetails(
                "Kinematics exercise",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/MlOkyPOCn" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/yzg0EGjCJ" },
                },
                new List<string> { "JavaScript", "p5.js", }
            )
        },
        {
            "floodfillexercise",
            new ResourceDetails(
                "Flood fill exercise",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Question", "https://editor.p5js.org/benchiverton/sketches/OXtuzLfV6" },
                    { "Solution", "https://editor.p5js.org/benchiverton/sketches/7Vv1fnlvj" },
                },
                new List<string> { "JavaScript", "p5.js", }
            )
        },
    };

    public IReadOnlyDictionary<string, ResourceDetails> GetResources(string filter) => _resources.Where(r =>
        r.Value.Name.Contains(filter, System.StringComparison.OrdinalIgnoreCase)
        || r.Value.Tags.Any(t => t.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
    ).ToDictionary(x => x.Key, x => x.Value);

    public bool TryGetResourceDetails(string resourceId, out ResourceDetails resourceDetails) => _resources.TryGetValue(resourceId, out resourceDetails);
}
