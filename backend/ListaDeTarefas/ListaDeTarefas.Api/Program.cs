using DotNetEnv;
using ListaDeTarefas.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

Env.Load();
var connectionString = Env.GetString("DB_CONNECTION_STRING");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddOpenApi();
builder.Services.AddControllers();

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
app.MapControllers();

app.Run();