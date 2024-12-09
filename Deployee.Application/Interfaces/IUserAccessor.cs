using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Interfaces;

/// <summary>
/// Interface to access user-specific information from the current HTTP context.
/// </summary>
public interface IUserAccessor
{
    /// <summary>
    /// Gets the user's unique identifier (ID).
    /// </summary>
    /// <returns>The user's ID as a string.</returns>
    string GetUserId();

    /// <summary>
    /// Gets the user's email address.
    /// </summary>
    /// <returns>The user's email address as a string.</returns>
    string GetEmail();

    /// <summary>
    /// Gets the user's username.
    /// </summary>
    /// <returns>The user's username as a string.</returns>
    string GetUserName();

    /// <summary>
    /// Gets the user's first name.
    /// </summary>
    /// <returns>The user's first name as a string.</returns>
    string GetUserFirstName();

    /// <summary>
    /// Gets the user's last name.
    /// </summary>
    /// <returns>The user's last name as a string.</returns>
    string GetUserLastName();

    /// <summary>
    /// Gets the user's role.
    /// </summary>
    /// <returns>The user's role as a string.</returns>
    string GetUserRole();

    /// <summary>
    /// Determines whether the user is authenticated.
    /// </summary>
    /// <returns>True if the user is authenticated, otherwise false.</returns>
    bool IsUserAuthenticated();

    /// <summary>
    /// Retrieves specific information about the currently logged-in user based on the provided info type.
    /// </summary>
    /// <returns>
    /// A string containing the requested information (e.g., profile picture URL, address, phone number),
    /// or null if the information is not available or the infoType is invalid.
    /// </returns>
    string GetUserInfo(string infoType);

}