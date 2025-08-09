using Microsoft.Extensions.DependencyInjection;
using SBEManagementSuite.UI.ViewModels;
namespace SBEManagementSuite.UI.Helpers
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            
            services.AddTransient<DockerContainersStatusViewModel>();



            // Always last in the list!
            services.AddTransient<MainWindowViewModel>();
            return services;
        }
    }
}
