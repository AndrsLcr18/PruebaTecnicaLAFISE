using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaLAFISE.DTOs
{
    public class BalanceCuentaDTO
    {
        [Required]
        public required string NumeroCuenta { get; set; }
        public decimal SaldoActual { get; set; }
    }
}
