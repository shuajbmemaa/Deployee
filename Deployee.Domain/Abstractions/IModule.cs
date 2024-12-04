using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deployee.Domain.Abstractions;

public interface IModule
{
    void Load(IServiceCollection services);
}

