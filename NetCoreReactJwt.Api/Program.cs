using Microsoft.EntityFrameworkCore;
using NetCoreReactJwt.Api.Configuration;
using NetCoreReactJwt.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();





//Swagger teste API
builder.Services.AddSwaggerConfiguration();

//Injeção de dependencia IRepository e IManager
builder.Services.AddDependencyInjectionConfiguration();

//Automapper - Mapeamento
builder.Services.AddAutoMapperConfiguration();

//Conexao com o banco de dados
builder.Services.AddDbContext<ContextDBConexao>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConexaoNetCoreReactJwt")));



//Curso posição 23:26
//https://www.youtube.com/watch?v=FSUa8Vd-td0



////FluentValidation
//services.AddFluentValidationConfiguration();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.UseSwaggerConfiguration();
}


//Garantindo a integridade estrutural do BD na subida da aplicação
app.UseDataBaseConfiguration();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
