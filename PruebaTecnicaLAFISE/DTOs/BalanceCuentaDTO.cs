using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaLAFISE.DTOs
{
    public class BalanceCuentaDTO
    {   //numero de cuenta
        [Required]
        public required string NumeroCuenta { get; set; }
        //Saldo actual de la cuenta
        public decimal SaldoActual { get; set; }
    }
}
