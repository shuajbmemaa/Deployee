using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Models.Identity;

public class LoginRequestt
{
    /// <summary>
    /// The email of the user that is trying to log in.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The password of the user that is trying to log in.
    /// </summary>
    public string Password { get; set; }
}