using AutoMapper;
using Deployee.Domain.Entities;
using Deployee.Models;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using System.Diagnostics.Metrics;
using System.Net;

namespace Deployee.Mapping;

public class WebMappingProfile : Profile
{
    public WebMappingProfile()
    {
        CreateMap<Department, DepartmentViewModel>();
    }
}

