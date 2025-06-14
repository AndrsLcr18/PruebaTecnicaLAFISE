using System.Text.Json.Serialization;
using System.Transactions;

namespace PruebaTecnicaLAFISE.Models
{
    public class Cuenta
    {
        public Int64 Id { get; set; }// Identificador único de la cuenta
        public string NumeroCuenta { get; set; } = Guid.NewGuid().ToString("N");// Genera un número de cuenta único por defecto
        public decimal Saldo { get; set; }// Saldo actual de la cuenta

        public Int64 IdCliente { get; set; }// Identificador del cliente al que pertenece la cuenta

        public Int64 ClienteId { get; set; }// Identificador del cliente al que pertenece la cuenta FK
        [JsonIgnore] 
        public Cliente Cliente { get; set; } = null!;// Cliente al que pertenece la cuenta
        [JsonIgnore]
        public ICollection<Transaccion> Transacciones { get; set; } = new List<Transaccion>();// Lista de transacciones asociadas a la cuenta
    }
}
