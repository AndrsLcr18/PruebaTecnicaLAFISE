using PruebaTecnicaLAFISE.Models;
using System.Security.Principal;

namespace PruebaTecnicaLAFISE.Services
{
    public interface IServicioCuenta
    {   // Interfaz para el servicio de cuenta
        Task<Cuenta> CrearCuentaAsync(Int64 clientId, decimal saldoInicial);
        Task<decimal> GetSaldoAsync(string numeroCuenta);
        Task<Transaccion> DepositoAsync(string numeroCuenta, decimal monto);
        Task<Transaccion> RetiroAsync(string numeroCuenta, decimal monto);
        Task<IEnumerable<Transaccion>> GetTransaccionesAsync(string numeroCuenta);
        Task GetSaldosAsync(string numeroCuenta);
        Task CrearCuentasAsync(Int64 clientId, decimal saldoInicial);

    }

}
