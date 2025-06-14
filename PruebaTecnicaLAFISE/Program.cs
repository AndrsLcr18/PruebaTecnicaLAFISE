using AutoMapper; // Add this directive to resolve AddAutoMapper method  
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore; // Ensure this directive is present  
using Microsoft.EntityFrameworkCore.Sqlite; // Add this directive to resolve the UseSqlite method  
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.Services;

var builder = WebApplication.CreateBuilder(args);
//biblioteca que permite el uso de SQLite.
SQLitePCL.Batteries.Init();
// Leer cadena de conexión desde appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configurar el contexto de la base de datos para usar SQLite
builder.Services.AddDbContext<LAFISEDbContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Registra el servicio de mantenimiento de cuentas  
builder.Services.AddScoped<IServicioCuenta, ServicioCuenta>();
// Registra el servicio de mantenimiento de clientes  
builder.Services.AddScoped<IServicioCliente, ServicioCliente>();

//Agregar la referencia de AutoMapper  
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();