using Microsoft.Extensions.DependencyInjection;
using NetCoreReactJwt.BusinessManager.Implementation;
using NetCoreReactJwt.BusinessManager.Interfaces;
using NetCoreReactJwt.Infrastructure.Data.Repository;


namespace NetCoreReactJwt.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Injeção de dependencia IRepository e IManager
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClienteBusinessManager, ClienteBusinessManager>();

            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<ISchedulingBusinessManager, SchedulingBusinessManager>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusinessManager, UserBusinessManager>();
        }
    }
}
