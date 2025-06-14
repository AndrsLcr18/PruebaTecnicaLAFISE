using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Moq;
using PruebaTecnicaLAFISE.Controllers;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;
using PruebaTecnicaLAFISE.Services;
using System.Threading.Tasks;
using Xunit;

public class CuentasControllerTests
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly LAFISEDbContext _context;
    public CuentasControllerTests()
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
    public async Task CrearCuentaAsync()
    {
        // Crear instancia de ServicioCuenta con el contexto configurado
        var _servicioCuenta = new ServicioCuenta(_context);
        // Arrange
        long idCliente = 1;
        decimal saldoInicial = 1000;

        // Act
        var cuenta = await _servicioCuenta.CrearCuentaAsync(idCliente, saldoInicial);

        // Assert
        Assert.NotNull(cuenta);
        Assert.Equal(idCliente, cuenta.IdCliente);
        Assert.Equal(saldoInicial, cuenta.Saldo);
    }

    [Fact]
    public async Task GetSaldoAsync()
    {
        // Crear instancia de ServicioCuenta con el contexto configurado
        var _servicioCuenta = new ServicioCuenta(_context);
        // Arrange
        var cuenta = new Cuenta { NumeroCuenta = "12345", Saldo = 500 };
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        // Act
        var saldo = await _servicioCuenta.GetSaldoAsync("12345");

        // Assert
        Assert.Equal(500, saldo);
    }

    [Fact]
    public async Task DepositoAsync()
    {
        // Crear instancia de ServicioCuenta con el contexto configurado
        var _servicioCuenta = new ServicioCuenta(_context);

        // Arrange
        var cuenta = new Cuenta { NumeroCuenta = "12345", Saldo = 500, Transacciones = new List<Transaccion>() };
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        // Act
        var transaccion = await _servicioCuenta.DepositoAsync("12345", 200);

        // Assert
        Assert.Equal(700, cuenta.Saldo);
        Assert.Equal(200, transaccion.Monto);
        Assert.Equal(TipodeTransaccion.Deposito, transaccion.Tipo);
    }

    [Fact]
    public async Task RetiroAsync()
    {
        // Crear instancia de ServicioCuenta con el contexto configurado
        var _servicioCuenta = new ServicioCuenta(_context);

        // Arrange
        var cuenta = new Cuenta { NumeroCuenta = "12345", Saldo = 10000, Transacciones = new List<Transaccion>() };
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        // Act
        var transaccion = await _servicioCuenta.RetiroAsync("12345", 200);

        // Assert
        Assert.Equal(9800, cuenta.Saldo);
        Assert.Equal(200, transaccion.Monto);
        Assert.Equal(TipodeTransaccion.Retiro, transaccion.Tipo);
    }
    [Fact]
    public async Task GetTransaccionesAsyncs()
    {
        // Crear instancia de ServicioCuenta con el contexto configurado
        var _servicioCuenta = new ServicioCuenta(_context);

        // Arrange
        var cuenta = new Cuenta
        {
            NumeroCuenta = "12345",
            Transacciones = new List<Transaccion>
        {
            new Transaccion { Monto = 100, Tipo = TipodeTransaccion.Deposito, Mensaje="Se realizo el deposito." },
            new Transaccion { Monto = 50, Tipo = TipodeTransaccion.Retiro ,Mensaje="Se realizo el retiro." }
        }
        };
        _context.Cuentas.Add(cuenta);
        await _context.SaveChangesAsync();

        // Act
        var transacciones = await _servicioCuenta.GetTransaccionesAsync("12345");

        // Assert
        Assert.Equal(2, transacciones.Count());
    }


}