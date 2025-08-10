using Microsoft.Extensions.DependencyInjection;
using SBEManagementSuite.Shared.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBEManagementSuite.Shared.Services
{
    public static class RegisterServices
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IDockerService, DockerService>();

            return services;
        }
    }
}
