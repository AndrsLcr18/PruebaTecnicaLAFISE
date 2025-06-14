using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaLAFISE.DTOs
{
    public class CrearCuentaDTO
    {
        [Required]
        public Int64 IdCliente { get; set; }

        [Range(0, double.MaxValue)]
        public decimal SaldoInicial { get; set; }
    }
}
