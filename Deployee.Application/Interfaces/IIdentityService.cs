using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Application.Interfaces;

public interface IIdentityService
{

    //Task<Result<bool>> RegisterAsync(RegisterRequest request);


    //Task<Result<bool>> LoginAsync(LoginRequest request);


    Task LogoutAsync();
}