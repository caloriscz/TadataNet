using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TadataNet.Common.Entities;

public class UserSetting
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string KeyParam { get; set; }
    [Required]
    public string KeyValue { get; set; }
    [Required]
    public Account Account { get; set; }
}
