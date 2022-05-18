using CompanyApp.Application.Employees;
using CompanyApp.Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace CompanyApp.Infrastructure
{
    public static class Setup
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, bool isProduction)
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
            services.AddSingleton<IEmployeeRepository, ExampleEmployeeRepository>();
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
