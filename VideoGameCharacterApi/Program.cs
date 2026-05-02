using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Scalar.AspNetCore;
using VideoGameCharacterApi.DataBase;
using VideoGameCharacterApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


// connect db sql server 
builder.Services.AddDbContext<AppDbContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// bring in services
builder.Services.AddScoped<IVedioGameCharacterService, VedioGameCharacterService>();

var app = builder.Build();

// Automatically apply database migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        dbContext.Database.Migrate();
    }
    catch (Microsoft.Data.SqlClient.SqlException ex) when (ex.Number == 1801)
    {
        app.Logger.LogWarning("Skipping startup migration because the database already exists.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.MapGet("/scalar", () => Results.Redirect("/scalar/v1"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
