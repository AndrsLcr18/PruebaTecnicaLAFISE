using System.Text.Json.Serialization;

namespace PruebaTecnicaLAFISE.Models
{
    public enum TipodeTransaccion
    {
        Deposito,//0 Representa una transacción de depósito
        Retiro //1 Representa una transacción de retiro
    }

    public class Transaccion
    {
        // Identificador único de la transacción
        public Int64 Id { get; set; }
        //tipo de transacción, puede ser Deposito o Retiro
        public TipodeTransaccion Tipo { get; set; }
        // Monto de la transacción
        public decimal Monto { get; set; }
        //Fecha y hora de la transacción, por defecto es la fecha actual 
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        // Saldo disponible posterior a la transacción
        public decimal DisponibleDepuesTransaccion { get; set; }

        // Identificador de la cuenta asociada a la transacción
        public Int64 IdCuenta { get; set; }
        // Identificador de la cuenta asociada a la transacción FK
        public Int64 CuentaId { get; set; }

        [JsonIgnore]
        // Cuenta asociada a la transacción
        public Cuenta Cuenta { get; set; } = null!;
        // Mensaje de la transacción
        public string Mensaje { get; set; } = null!; 
    }
}
