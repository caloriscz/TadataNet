using System.ComponentModel.DataAnnotations;

namespace TadataNet.Common.Accounts;

public class ForgotPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}