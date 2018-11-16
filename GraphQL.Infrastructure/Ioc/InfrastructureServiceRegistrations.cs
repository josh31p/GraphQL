
using GraphQL.Core.Data;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.Infrastructure.Ioc
{
    public static class InfrastructureServiceRegistrations
    {
        public static IServiceCollection RegisterInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddSingleton <IStoreRepository, StoreRepository>();
            return services;
        }
        
    }
}
