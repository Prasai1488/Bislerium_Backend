namespace BisleriumBloggers.DTOs.Account;

// Data transfer object for registration information
public class RegisterDto
{

    // Username field
    public string Username { get; set; }

    public string EmailAddress { get; set; }

    public string FullName { get; set; }

    public string Password { get; set; }

    public string MobileNumber { get; set; }

    public string ImageURL { get; set; }
}
