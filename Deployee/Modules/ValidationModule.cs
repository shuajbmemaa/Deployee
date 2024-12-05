using Deployee.Domain.Abstractions;
using Deployee.Models;
using Deployee.Validators;
using Deployee.Web.Validators;
using FluentValidation;

namespace Deployee.Modules;

public class ValidationModule : IModule
{
    public void Load(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<RegisterViewModel>();
        services.AddScoped<IValidator<RegisterViewModel>, RegisterViewModelValidator>();
        services.AddScoped<IValidator<LoginViewModel>, LoginModelValidator>();
        services.AddScoped<IValidator<LoginViewModel>, LoginModelValidator>();
    }
}