using Deployee.Application.Models.Identity;
using Deployee.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Interfaces;

public interface IIdentityService
{
    Task<Result<bool>> RegisterAsync(RegisterRequestt request);

    Task<Result<bool>> LoginAsync(LoginRequestt request);

    Task LogoutAsync();
}