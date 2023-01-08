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
            "technicalmanagementandleadership",
            new ResourceDetails(
                "Technical management and leadership",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Refacoring technical leadership blogs (paid)", "https://refactoring.fm/about" },
                    { "HBS leadership blogs", "https://online.hbs.edu/blog/?topic=Leadership" },
                    { "HBS management blogs", "https://online.hbs.edu/blog/?topic=Management" },
                },
                new List<string> { "Management", "Leadership" }
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
            "delegation",
            new ResourceDetails(
                "Delegation",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "How to delegate effectively: 9 tips for managers (HBS)", "https://online.hbs.edu/blog/post/how-to-delegate-effectively" },
                    { "Management Time: Who’s Got the Monkey? (HBR)", "https://hbr.org/1999/11/management-time-whos-got-the-monkey" },
                },
                new List<string> { "Management", "Leadership" }
            )
        },
        {
            "careerframeworks",
            new ResourceDetails(
                "Career frameworks",
                new Dictionary<string, string>
                {
                    { "Matrix framework - CircleCI.xlsx", "BenChiverton.Blog.Resources.Downloads.career_frameworks.circle_ci.xlsx" },
                    { "Matrix framework - Rent The Runway.xlsx", "BenChiverton.Blog.Resources.Downloads.career_frameworks.rent_the_runway.xlsx" },
                    { "Simple level progression - Etsy.pdf", "BenChiverton.Blog.Resources.Downloads.career_frameworks.etsy.pdf" },
                },
                new Dictionary<string, string>
                {
                    { "Career Frameworks — Part 1", "https://refactoring.fm/p/career-frameworks-1" },
                    { "Engineering growth at Medium", "https://medium.engineering/engineering-growth-at-medium-4935b3234d25" },
                },
                new List<string> { "Management", "Leadership" }
            )
        },
        {
            "leadershipmanagementtraining",
            new ResourceDetails(
                "Leadership and management training",
                new Dictionary<string, string>(),
                new Dictionary<string, string>
                {
                    { "Which HBS online leadership and management course is right for you?", "https://online.hbs.edu/blog/post/management-and-leadership-courses-online" },
                },
                new List<string> { "Management", "Leadership", "Training" }
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
