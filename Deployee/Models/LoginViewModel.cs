namespace Deployee.Models;

public class LoginViewModel
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// This is required and must be a valid email address.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the password for the user.
    /// This is required and should be a secure password.
    /// </summary>
    public string Password { get; set; }
}