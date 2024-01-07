using ApiWithSQLConnection.Models.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container.

// Adiciona os serviços do MySQL
builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL(
    builder.Configuration["dbContextSettings:ConnectionString"]));

// Adiciona HttpClient ao container de serviços
builder.Services.AddHttpClient();

// Adiciona controllers
builder.Services.AddControllers();

// Configurações para Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura o pipeline de requisições HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
