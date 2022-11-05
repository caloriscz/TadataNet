using System.ComponentModel.DataAnnotations;

namespace TadataNet.Common.Accounts;

public class ValidateResetTokenRequest
{
    [Required]
    public string Token { get; set; }
}