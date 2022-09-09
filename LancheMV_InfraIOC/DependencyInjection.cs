using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LancheMV_InfraIOC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfiguraçãoServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Method intentionally left empty.

            return services;
        }

    }
}
