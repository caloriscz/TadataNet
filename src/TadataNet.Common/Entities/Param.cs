using System.ComponentModel.DataAnnotations;

namespace TadataNet.Common.Entities;

public class Param
{
    [Key]
    public int TagName { get; set; }
}
