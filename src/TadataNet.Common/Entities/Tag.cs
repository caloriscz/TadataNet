using System.ComponentModel.DataAnnotations;

namespace TadataNet.Common.Entities;

public class Tag
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string TagName { get; set; }
}
