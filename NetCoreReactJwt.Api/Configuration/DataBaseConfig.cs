using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreReactJwt.Infrastructure.Data;


namespace NetCoreReactJwt.Api.Configuration
{
    public static class DataBaseConfig
    {
        
        //ConexaoBD - Garantindo a integridade estrutural da base de dados na subida da aplicação
        public static void UseDataBaseConfiguration(this IApplicationBuilder app)
        {
            //Acessando o Contexto pelo ServiceScopeFactory para acessa a Injeção de Dependencia
            using var serviceScope =
                app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<ContextDBConexao>();

            //Aplica as configurações pendentes quando é chamado verificando todos os Migrate disponivél dando (update-database)
            context.Database.Migrate();

            //Aplica as configurações pendentes quando é chamado verificando todos os Migrate disponivél garantido que a base de dados esta criada
            context.Database.EnsureCreated();
        }
    }
}
