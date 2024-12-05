using Asp.Versioning;
using Deployee.Application.Mappings;
using Deployee.Domain.Abstractions;
using Deployee.Mapping;
using NuGet.Configuration;

namespace Deployee.Modules;

public class CoreModule : IModule
{
    private readonly IConfiguration _configuration;

    public CoreModule(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Load(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddAutoMapper(typeof(ApplicationMappingProfiles).Assembly, typeof(WebMappingProfile).Assembly);
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });
    }
}
