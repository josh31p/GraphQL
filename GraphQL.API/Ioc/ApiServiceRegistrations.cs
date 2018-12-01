using AutoMapper;
using GraphQL.API.Queries;
using GraphQL.API.Schemas;
using GraphQL.API.Types;
using GraphQL.Infrastructure.Ioc;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GraphQL.API.Ioc
{
    public static class ApiServiceRegistrations
    {
        public static IServiceCollection RegisterApiDependencies(this IServiceCollection services)
        {
            services.AddMvc();
            services.AddAutoMapper(typeof(Startup));
            services.RegisterInfrastructureDependencies();

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ISchema, StoreSchema>();
            services.AddSingleton<StoreQuery, StoreQuery>();
            services.AddTransient<StoreType, StoreType>();

            var sp = services.BuildServiceProvider();
            services.AddScoped<ISchema>(_ => new StoreSchema(type => (GraphType)sp.GetService(type)) { Query = sp.GetService<StoreQuery>() });

            
            return services;
        }
    }
}
