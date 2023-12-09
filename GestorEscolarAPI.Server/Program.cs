using GestorEscolarAPI.Server.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Crear variable para la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("GestorEscolarConnection");

// Registrar servicios para la conexión
builder.Services.AddDbContext<GestorEscolarContext>(options => options.UseSqlServer(connectionString));

// Configurar CORS (Cambia tu puerto para que no sean bloqueadas las peticiones)
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy",
        builder =>
        {
            builder.WithOrigins("https://localhost:5173") // URL de tu frontend
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Usar CORS
app.UseCors("MyPolicy");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.Run();
