namespace Deployee.Models;

public class RegisterViewModel
{
    /// <summary>
    /// Gets or sets the email address of the user.
    /// This is required and must be a valid email address.
    /// </summary>
    public string Email { get; init; }

    /// <summary>
    /// Gets or sets the password for the user.
    /// This is required and should be a secure password.
    /// </summary>
    public string Password { get; init; }

    /// <summary>
    /// Gets or sets the confirmation password.
    /// This is required and must match the password.
    /// </summary>
    public string ConfirmPassword { get; init; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// This is required.
    /// </summary>
    public string FirstName { get; init; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// This is required.
    /// </summary>
    public string LastName { get; init; }
}