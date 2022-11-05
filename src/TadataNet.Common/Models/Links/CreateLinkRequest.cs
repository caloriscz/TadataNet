using System.ComponentModel.DataAnnotations.Schema;

namespace TadataNet.Common.Models.Links;

public class CreateLinkRequest
{
    public string Title { get; set; }
    [NotMapped]
    public string Url { get; set; }
    public string Description { get; set; } = null!;
}
