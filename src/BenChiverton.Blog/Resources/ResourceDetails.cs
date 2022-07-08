using System.Collections.Generic;

namespace BenChiverton.Blog.Resources;

public record ResourceDetails(
    string Name,
    Dictionary<string, string> ResourceLinks,
    List<string> Tags
);
