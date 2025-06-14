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
        public Int64 Id { get; set; }// Identificador único de la transacción
        public TipodeTransaccion Tipo { get; set; }//tipo de transacción, puede ser Deposito o Retiro
        public decimal Monto { get; set; }// Monto de la transacción
        public DateTime Fecha { get; set; } = DateTime.UtcNow;//Fecha y hora de la transacción, por defecto es la fecha actual 
        public decimal DisponibleDepuesTransaccion { get; set; }// Saldo disponible posterior a la transacción

        public Int64 IdCuenta { get; set; }// Identificador de la cuenta asociada a la transacción
        public Int64 CuentaId { get; set; }// Identificador de la cuenta asociada a la transacción FK

        [JsonIgnore] //
        public Cuenta Cuenta { get; set; } = null!;// Cuenta asociada a la transacción
        public string Mensaje { get; set; } = null!; // Mensaje de la transacción
    }
}
