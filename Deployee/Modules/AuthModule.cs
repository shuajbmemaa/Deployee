using Deployee.Domain.Abstractions;
using Deployee.Domain.Entities;
using Deployee.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using System;

namespace Deployee.Modules;

public class AuthModule : IModule
{
    public void Load(IServiceCollection services)
    {
        services
        .AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(options =>
        {
            options.LoginPath = "/Users/Login";
        });
    }
}
