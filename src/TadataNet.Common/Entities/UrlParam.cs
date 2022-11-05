using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TadataNet.Common.Entities;

public class UrlParam
{
    [Key]
    public int Id { get; set; }
    public int UrlId { get; set; }
    [ForeignKey(nameof(UrlId))]
    public Url Url { get; set; }
    public int TagId { get; set; }
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
}
