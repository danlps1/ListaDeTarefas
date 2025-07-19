using DotNetEnv;
using ListaDeTarefas.Application.Interfaces;
using ListaDeTarefas.Application.Services;
using ListaDeTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
var connectionString = Env.GetString("DB_CONNECTION_STRING");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirRequisicoes", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<ITarefaInterface, TarefaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options
            .WithTitle("Api Documentation")
            .WithTheme(ScalarTheme.Purple);
    });
}

app.UseHttpsRedirection();
app.UseCors("PermitirRequisicoes");
app.MapControllers();

app.Run();