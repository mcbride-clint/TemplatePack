using CompanyApp.Application.Employees;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyApp.Application
{
    public static class Setup
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, bool isProduction)
        {
            if (isProduction)
            {
                services.AddProductionDependencies();
            }
            else
            {
                services.AddDevelopmentDependencies();
            }

            services.AddDefaultDependencies();
            
            return services;
        }

        public static IServiceCollection AddDefaultDependencies(this IServiceCollection services)
        {
            services.AddSingleton<EmployeeService>();
            return services;
        }

        public static IServiceCollection AddProductionDependencies(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDevelopmentDependencies(this IServiceCollection services)
        {
            return services;
        }
    }
}
