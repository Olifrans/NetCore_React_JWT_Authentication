using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace NetCoreReactJwt.Api.Configuration
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            //Swagger teste API
            services.AddSwaggerGen(c =>
            {
                //Documentação e informação sobre a API
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "NetCore React AuthenticationJWT - Olifrans",
                        Version = "v1",
                        Description = "Api NetCore React AuthenticationJWT",

                        Contact = new OpenApiContact
                        {
                            Name = "Francisco Olifrans",
                            Email = "fransoliveira@gamail.com",
                            Url = new Uri("https://github.com/Olifrans")
                        },

                        License = new OpenApiLicense
                        {
                            Name = "Todos os Direitos Reservados Francisco Olifrans.",
                            Url = new Uri("https://github.com/Olifrans")
                        },

                        TermsOfService = new Uri("https://github.com/Olifrans")
                    });



                //Bloco de código para Geração do token login de acesso do JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    //Description = "JWT Authorization header using the Bearer scheme.\r\n\r\n Enter 'Bearer'[space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                    Description = "Cabeçalho de autorização JWT usando o esquema Bearer." +
                    "\r\n\r\n Digite 'Portador' [espaço] e, em seguida, seu token na entrada de texto abaixo." +
                    "\r\n\r\n Exemplo: \"O portador  12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
            });
        }



        public static void UseSwaggerConfiguration(this IApplicationBuilder app)
        {           
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore React AuthenticationJWT - Olifrans v1"));
        }
    }
}
