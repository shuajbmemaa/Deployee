using Deployee.Models;
using FluentValidation;

namespace Deployee.Web.Validators;

public class RegisterViewModelValidator : AbstractValidator<RegisterViewModel>
{
    public RegisterViewModelValidator()
    {
        RuleFor(x => x.Email)
           .NotEmpty().WithMessage("Email is required.")
           .EmailAddress().WithMessage("A valid email address is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
            .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches("[0-9]").WithMessage("Password must contain at least one number.")
            .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Confirmation password is required.")
            .Equal(x => x.Password).WithMessage("Password and confirmation password must match.");

        RuleFor(x => x.FirstName)
           .NotEmpty().WithMessage("First name is required.")
           .Matches("^[a-zA-Z]+$").WithMessage("First name must contain only letters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .Matches("^[a-zA-Z]+$").WithMessage("Last name must contain only letters.");
    }
}