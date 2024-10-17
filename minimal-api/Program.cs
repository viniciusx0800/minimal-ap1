var builder = WebApplication.CreateBuilder(args);
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
public class LoginDTO
{
    public string Email { get; set; } = default!;
    public string Senha { get; set; } = default!;
}