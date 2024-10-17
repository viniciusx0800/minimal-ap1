using System.Data.Common;
using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.DTOs;
using minimal_api.Infraestrutura.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbContexto>(options => {
    options.UseMySql(
        builder.Configuration.GetConnectionString("mysql"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
    );
});



var app = builder.Build();

app.MapGet("/", () => "ola, ed!");

app.MapPost("/login", static (LoginDTO loginDTO) =>{
    if (loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
        return Results.Ok("login com sucesso"); 
    else
    {
        return Results.Unauthorized();
    }       
    
});



app.Run();