using Microsoft.EntityFrameworkCore;
using api.Data;
using api.services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Ajoute les services MVC (contrôleurs)
var allowedOrigin = builder.Configuration["AllowedOrigin"];
Console.WriteLine($"AllowedOrigin: {allowedOrigin}");

builder.Services.AddCors(options =>
{
    if (allowedOrigin != null)
    {
         options.AddPolicy(name: "AllowAngularDev",
        policy =>
        {
            policy.WithOrigins(allowedOrigin) // Front
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
    }
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Services
builder.Services.AddScoped<VerbService>();

// Configuration de la chaîne de connexion
var connectionString = "";
if (builder.Environment.IsDevelopment())
{
    connectionString = builder.Configuration.GetConnectionString("dev-connection");
}
else
{
    var host = Environment.GetEnvironmentVariable("PGHOST");
    var database = Environment.GetEnvironmentVariable("PGDATABASE");
    var user = Environment.GetEnvironmentVariable("PGUSER");
    var password = Environment.GetEnvironmentVariable("PGPASSWORD");

    connectionString = $"Host={host};Database={database};Username={user};Password={password}";
}
builder.Services.AddDbContext<JPVerbLearnerContext>(
    options => options.UseNpgsql(connectionString)
);

// Build
var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors("AllowAngularDev"); 
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<JPVerbLearnerContext>();
        await DbSeeder.SeedAsync(context); // ← On passe ici le DbContext
    }
}

app.Run();
