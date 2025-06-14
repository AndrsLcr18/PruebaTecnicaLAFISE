using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaLAFISE.DTOs
{
    public class CrearCuentaDTO
    {
        // Identificador del cliente al que se le creará la cuenta */
        [Required]
        public Int64 IdCliente { get; set; }
        // Saldo inicial de la cuenta, debe ser un valor positivo
        [Range(0, double.MaxValue)]
        public decimal SaldoInicial { get; set; }
    }
}
