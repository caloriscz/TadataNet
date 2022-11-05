using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TadataNet.Common.Entities;

public class Link
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    [Required]
    public string Title { get; set; }
    public DateTime DateCreated { get; set; }
    public int AccountId { get; set; }
    [ForeignKey(nameof(AccountId))]
    public Account Account { get; set; }
    public int UrlId { get; set; }
    [ForeignKey(nameof(UrlId))]
    public Url Url { get; set; }
}
