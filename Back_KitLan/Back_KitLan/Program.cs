using Back_KitLan.Data;
using Microsoft.EntityFrameworkCore;

string? connectionFront = Environment.GetEnvironmentVariable("URL_FRONT");

var builder = WebApplication.CreateBuilder(args);

// Définition d'une politique CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Ajout des services au conteneur
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine($"Connection String: {connectionString}");

// Configuration de CORS
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: MyAllowSpecificOrigins,
					  policy =>
					  {
						  policy.WithOrigins(connectionFront) // Autorise Angular 
								.AllowAnyHeader()
								.AllowAnyMethod();
					  });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Activation de Swagger en mode développement
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Activation de CORS (avant UseAuthorization)
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
