using Deployee.Application.Interfaces;
using Deployee.Application.Services;
using Deployee.Domain.Abstractions;
using Deployee.Domain.Interfaces;
using Deployee.Infrastructure.Data;
using Deployee.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;

namespace Deployee.Modules;

public class DataModule : IModule
{
    private readonly IConfiguration _configuration;

    public DataModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Load(IServiceCollection services)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");

        if (connectionString is null)
        {
            throw new ConfigurationErrorsException("Cannot find 'DefaultConnection' section inside the configuration");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
            options
                .UseSqlServer(connectionString)
                .AddInterceptors(new SoftDeleteInterceptor())
        );

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IUserAccessor, UserAccessor>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    }

