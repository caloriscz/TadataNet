using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TadataNet.Common.Entities;

public class LinkTag
{
    [Key]
    public int Id { get; set; }
    public int LinkId { get; set; }
    [ForeignKey(nameof(LinkId))]
    public Link Link { get; set; }
    public int TagId { get; set; }
    [ForeignKey(nameof(TagId))]
    public Tag Tag { get; set; }
}
