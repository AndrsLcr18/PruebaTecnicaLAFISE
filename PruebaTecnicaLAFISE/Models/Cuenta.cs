using System.Text.Json.Serialization;
using System.Transactions;

namespace PruebaTecnicaLAFISE.Models
{
    public class Cuenta
    {
        // Identificador único de la cuenta
        public Int64 Id { get; set; }
        // Genera un número de cuenta único por defecto
        public string NumeroCuenta { get; set; } = Guid.NewGuid().ToString("N");
        // Saldo actual de la cuenta
        public decimal Saldo { get; set; }
        // Identificador del cliente al que pertenece la cuenta
        public Int64 IdCliente { get; set; }
        // Identificador del cliente al que pertenece la cuenta FK
        public Int64 ClienteId { get; set; }

        // Cliente al que pertenece la cuenta
        [JsonIgnore] 
        public Cliente Cliente { get; set; } = null!;

        //transacciones asociadas a la cuenta
        [JsonIgnore]
        public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();// Lista de transacciones asociadas a la cuenta
    }
}
