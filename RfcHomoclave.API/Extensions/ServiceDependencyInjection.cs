using RfcHomoclave.Middleware.Contracts.Services;
using RfcHomoclave.Service;

namespace RfcHomoclave.API.Extensions
{
    public static class ServiceDependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.DependencyInjection();
            return services;
        }
        private static IServiceCollection DependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IServiceFactory, ServiceFactory>();
            return services;
        }
    }
}
