using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//  herramientas necesarias de :contentReference[oaicite:0]{index=0} para crear la app

//  CREACIÓN 

var builder = WebApplication.CreateBuilder(args);
//El builder, donde se configura toda la aplicación antes de ejecutarla


//  SERVICIOS

builder.Services.AddControllers();
// Activa el uso de controladores para crear endpoints (API)

builder.Services.AddEndpointsApiExplorer();
// Permite detectar automáticamente los endpoints (rutas de la API)

builder.Services.AddSwaggerGen();
// Agrega Swagger para documentar y probar la API desde el navegador


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
    );
});
// Configura CORS para permitir que cualquier aplicación externa consuma la API


//  BUILD 

var app = builder.Build();
// Construye la aplicación final con todo lo configurado anteriormente


//  CONFIGURACIÓN

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Activa Swagger solo en desarrollo para ver y probar la API


app.UseCors("AllowAll");
// Aplica la política CORS definida anteriormente

app.UseHttpsRedirection();
// Redirige automáticamente de HTTP a HTTPS (más seguro)

app.UseAuthorization();
// Habilita la autorización para controlar acceso a los endpoints

app.MapControllers();
// Conecta los controladores con las rutas para que funcionen

Console.WriteLine("");

Console.WriteLine("Hola Profe los comentarios  fueron colocados con ia ojo con fines de estudio.");

app.MapGet("/", () => "Hola Profe los comentarios  fueron colocados con ia ojo con fines de estudio.");
Console.WriteLine("");



//  EJECUCIÓN

app.Run();
// Inicia la aplicación y comienza a escuchar peticiones