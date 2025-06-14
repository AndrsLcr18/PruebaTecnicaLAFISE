using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.Models;
using System.Security.Principal;

namespace PruebaTecnicaLAFISE.Services
{
    public class ServicioCuenta : IServicioCuenta
    {
        private readonly IMapper _mapper;
        // Implementación del servicio de cuenta
        private readonly LAFISEDbContext _context;
        // Constructor que recibe el contexto de la base de datos
        public ServicioCuenta(LAFISEDbContext context)
        {
            _context = context;
        }

        public ServicioCuenta(LAFISEDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // Método para crear una nueva cuenta
        public async Task<Cuenta> CrearCuentaAsync(Int64 IdCliente, decimal SaldoInicial)
        {
            var cuenta = new Cuenta
            {
                IdCliente = IdCliente,
                ClienteId = IdCliente,
                Saldo = SaldoInicial
            };

            _context.Cuentas.Add(cuenta);
            await _context.SaveChangesAsync();
            return cuenta;
        }
        // Método para obtener el saldo de una cuenta
        public async Task<decimal> GetSaldoAsync(string numeroCuenta)
        {
            var cuenta = await _context.Cuentas
                .FirstOrDefaultAsync(a => a.NumeroCuenta == numeroCuenta);

            if (cuenta == null) throw new Exception("No se encontro la cuenta.");

            return cuenta.Saldo;
        }
        // Método para depositar dinero en una cuenta
        public async Task<Transaccion> DepositoAsync(string numeroCuenta, decimal monto)
        {
            var cuenta = await _context.Cuentas
                .Include(a => a.Transacciones)
                .FirstOrDefaultAsync(a => a.NumeroCuenta == numeroCuenta);

            if (cuenta == null) throw new Exception("No se encontro la cuenta.");

            cuenta.Saldo += monto;
            var transaccion = new Transaccion
            {
                IdCuenta = cuenta.Id,
                CuentaId= cuenta.Id,
                Monto = monto,
                Tipo = TipodeTransaccion.Deposito,
                DisponibleDepuesTransaccion = cuenta.Saldo,
                Mensaje = "Deposito realizado con exito."
            };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();
            return transaccion;
        }
        //  Método para retirar dinero de una cuenta
        public async Task<Transaccion> RetiroAsync(string numeroCuenta, decimal monto)
        {
            var cuenta = await _context.Cuentas
                .Include(a => a.Transacciones)
                .FirstOrDefaultAsync(a => a.NumeroCuenta == numeroCuenta);

            if (cuenta == null) throw new Exception("No se encontro la cuenta.");
            if (cuenta.Saldo < monto) throw new Exception("Saldo insuficientes / Fondos insuficientes");

            cuenta.Saldo -= monto;
            var transaccion = new Transaccion
            {
                IdCuenta = cuenta.Id,
                CuentaId = cuenta.Id,
                Monto = monto,
                Tipo = TipodeTransaccion.Retiro,
                DisponibleDepuesTransaccion = cuenta.Saldo,
                Mensaje = "Retiro realizado con exito."
            };

            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();
            return transaccion;
        }
        // Método para obtener las transacciones de una cuenta
        public async Task<IEnumerable<Transaccion>> GetTransaccionesAsync(string numeroCuenta)
        {
            var cuenta = await _context.Cuentas
                .Include(a => a.Transacciones)
                .FirstOrDefaultAsync(a => a.NumeroCuenta == numeroCuenta);

            if (cuenta == null) throw new Exception("No se encontro la cuenta.");

            return cuenta.Transacciones.OrderBy(t => t.Fecha);
        }

        public Task CrearCuentasAsync(long clientId, decimal saldoInicial)
        {
            throw new NotImplementedException();
        }

        public Task GetSaldosAsync(string numeroCuenta)
        {
            throw new NotImplementedException();
        }
    }

}
