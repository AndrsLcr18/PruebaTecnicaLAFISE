using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using PruebaTecnicaLAFISE.Controllers;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;
using PruebaTecnicaLAFISE.Services;
using System.Threading.Tasks;
using Xunit;

public class ClientesControllerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly LAFISEDbContext _context;

    public ClientesControllerTests()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            string? conecttionstring = configuration["ConnectionStrings:DefaultConnection"];
            if (conecttionstring == null)
            {
                throw new InvalidOperationException("La configuración 'DefaultConnection' no está definida en appsettings.json.");
            }

            // Configurar opciones de DbContext para usar una base de datos en memoria
            var options = new DbContextOptionsBuilder<LAFISEDbContext>()
                .UseInMemoryDatabase(conecttionstring)
                .Options;

            _context = new LAFISEDbContext(options);

            // Initialize the mock object for IMapper
            _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task CrearCliente()
    {
        // Arrange
        var clienteDto = new ClienteDTO
        {
            Nombre = "Ariel Rivera Lopez",
            Nacimiento = DateTime.UtcNow,
            Genero = "H",
            Ingreso = 0
        };

        // Configurar el mock de AutoMapper
        _mapperMock.Setup(m => m.Map<Cliente>(clienteDto)).Returns(new Cliente
        {
            Id = 0, // No asignamos ID manualmente, dejamos que el servicio lo haga
            Nombre = clienteDto.Nombre,
            Nacimiento = clienteDto.Nacimiento,
            Genero = clienteDto.Genero,
            Ingreso = clienteDto.Ingreso
        });

        // Crear instancia de ServicioCliente con el contexto y el mock de AutoMapper
        var _servicioCliente = new ServicioCliente(_context, _mapperMock.Object);

        // Act
        var result = await _servicioCliente.CrearClienteAsync(clienteDto);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Id > 0, $"El ID generado ({result.Id}) no es válido."); // Verificar que el ID sea mayor que 0 porque el método GenerateUniqueId genera un ID positivo
        Assert.Equal(clienteDto.Nombre, result.Nombre);
        Assert.Equal(clienteDto.Genero, result.Genero);
        Assert.Equal(clienteDto.Ingreso, result.Ingreso);
    }

        [Fact]
    public async Task ConsultarCliente()
    {

        // Crear instancia de ServicioCliente con el contexto configurado
        var _servicioCliente = new ServicioCliente(_context);

        // Arrange
        var Idcliente = 2351135132479303316;

        // Act
        var result = await _servicioCliente.GetClienteAsync(Idcliente);

        // Assert
        Assert.NotNull(result);

    }
}