namespace TadataNet.Common.Models.Links;

public class LinksResponse
{
    public int Id { get; set; }
    public string Url { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateCreated { get; set; }
}