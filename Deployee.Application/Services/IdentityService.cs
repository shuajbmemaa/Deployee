using Deployee.Application.Interfaces;
using Deployee.Application.Models.Identity;
using Deployee.Domain.Common;
using Deployee.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Services;

public sealed class IdentityService : IIdentityService
{
    private readonly ILogger<IIdentityService> _logger;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager, ILogger<IIdentityService> logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _logger = logger;
    }

    /// <summary>
    /// Handles user login operations.
    /// </summary>
    /// <param name="request">The login request containing email and password.</param>
    /// <returns>A result indicating success or failure of the login operation.</returns>
    public async Task<Result<bool>> LoginAsync(LoginRequestt request)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                _logger.LogError("Login failed for Email: {Email} - User not found.", request.Email);
                return Result<bool>.Failure(UsersErrors.IncorrectEmailOrPassword);
            }

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                _logger.LogInformation("Login succeeded for User with Email: {Email} ", request.Email);
                return Result<bool>.Success();
            }

            _logger.LogError("Login failed for Email: {Email} - Incorrect password.", request.Email);
            return Result<bool>.Failure(UsersErrors.IncorrectEmailOrPassword);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in {ServiceName} while attempting to log in User with Email: {Email}",
                             nameof(IdentityService), request.Email);
            return Result<bool>.Failure(UsersErrors.UnexpectedError);
        }
    }

    /// <summary>
    /// Handles user registration operations.
    /// </summary>
    /// <param name="request">The registration request containing user details and password.</param>
    /// <returns>A result indicating success or failure of the registration operation.</returns>
    public async Task<Result<bool>> RegisterAsync(RegisterRequestt request)
    {
        try
        {
            var userExists = await _userManager.Users.AnyAsync(x => x.Email == request.Email);
            if (userExists)
            {
                _logger.LogError("Registration failed for Email: {Email} - User already exists.", request.Email);
                return Result<bool>.Failure(UsersErrors.UserAlreadyExists(request.Email));
            }

            var user = new User
            {
                UserName = Guid.NewGuid().ToString(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                CreatedAt = DateTime.UtcNow,
            };

            _logger.LogInformation("Started registering User with Email: {Email} and CreatedAt: {CreatedAt}", request.Email, user.CreatedAt);

            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded is false)
            {
                return Result<bool>.Failure(UsersErrors.CreationFailed);
            }

            var userClaims = new List<Claim>
                {
                     new Claim(ClaimTypes.NameIdentifier, user.Id),
                     new Claim(ClaimTypes.Email, user.Email),
                     new Claim(ClaimTypes.GivenName, user.FirstName),
                     new Claim(ClaimTypes.Surname, user.LastName),
                     new Claim(ClaimTypes.Role, "User")
                };

            var claimResult = await _userManager.AddClaimsAsync(user, userClaims);

            if (claimResult.Succeeded is false)
            {
                _logger.LogError("User creation failed for Email: {Email} with Errors: {Errors}",
                                 request.Email, string.Join(",", result.Errors.Select(x => x.Description)));

                return Result<bool>.Failure(UsersErrors.ClaimFailed);
            }

            _logger.LogInformation("User registered successfully with Email: {Email}", request.Email);
            return Result<bool>.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in {ServiceName} while attempting to register User with Email: {Email}",
                             nameof(IdentityService), request.Email);
            return Result<bool>.Failure(UsersErrors.UnexpectedError);
        }
    }

    /// <summary>
    /// Logs out the currently authenticated user.
    /// </summary>
    public async Task LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out successfully.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while logging out the user.");
        }
    }
}