using TadataNet.Common.Models.Links;

public class UpdateLinkRequest
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Description { get; set; } = null!;
}