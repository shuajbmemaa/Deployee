using Deployee.Application.Interfaces;
using Deployee.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Services;

public class UserAccessor : IUserAccessor
{
    private readonly UserManager<User> _userManager;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserAccessor(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Retrieves the unique identifier of the currently authenticated user.
    /// </summary>
    /// <returns>The user ID as a string, or null if not authenticated.</returns>
    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    /// <summary>
    /// Retrieves the email address of the currently authenticated user.
    /// </summary>
    /// <returns>The user's email address as a string, or null if not authenticated.</returns>
    public string GetEmail()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Email);
    }

    /// <summary>
    /// Retrieves the username of the currently authenticated user.
    /// </summary>
    /// <returns>The user's username as a string, or null if not authenticated.</returns>
    public string GetUserName()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
    }

    /// <summary>
    /// Retrieves the first name of the currently authenticated user.
    /// </summary>
    /// <returns>The user's firstName as a string, or null if not authenticated.</returns>
    public string GetUserFirstName()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.GivenName);
    }

    /// <summary>
    /// Retrieves the last name of the currently authenticated user.
    /// </summary>
    /// <returns>The user's LastName as a string, or null if not authenticated.</returns>
    public string GetUserLastName()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Surname);
    }


    /// <summary>
    /// Retrieves the role of the currently authenticated user.
    /// </summary>
    /// <returns>The user's role as a string, or null if not authenticated.</returns>
    public string GetUserRole()
    {
        return _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
    }

    /// <summary>
    /// Determines if the current user is authenticated.
    /// </summary>
    /// <returns>True if the user is authenticated; otherwise, false.</returns>
    public bool IsUserAuthenticated()
    {
        return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }

    public string GetUserInfo(string infoType)
    {
        throw new NotImplementedException();
    }
}
