using System.ComponentModel.DataAnnotations;

namespace BisleriumBloggers.DTOs.Account;

 // Data transfer object for login information
public class LoginDto
{
    // Email address field with required validation
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; }

// Password field with required validation
    [Required]
    public string Password { get; set; }
}
