using GraphQL.API.Queries;
using GraphQL.API.Schemas;
using GraphQL.Infrastructure.Ioc;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.API.Ioc
{
    public static class ApiServiceRegistrations
    {
        public static IServiceCollection RegisterApiDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ISchema, StoreSchema>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new StoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<StoreQuery>() });

            services.RegisterInfrastructureDependencies();
            return services;
        }
    }
}
