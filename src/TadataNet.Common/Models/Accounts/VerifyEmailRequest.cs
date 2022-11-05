using System.ComponentModel.DataAnnotations;

namespace TadataNet.Common.Accounts;

public class VerifyEmailRequest
{
    [Required]
    public string Token { get; set; }
}