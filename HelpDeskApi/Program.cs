using Microsoft.EntityFrameworkCore;
using HelpDeskApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Adicionando os serviços padrão da API (Controllers, Swagger, etc)
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ---> A CONEXÃO COM O BANCO DE DADOS ENTRA AQUI <---
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// A linha abaixo "tranca" as configurações. Tudo tem que ser adicionado ANTES dela!
var app = builder.Build(); 

// Configurando o Swagger (Para testar a API depois)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

