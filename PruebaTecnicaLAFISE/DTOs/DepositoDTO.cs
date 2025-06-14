using System.ComponentModel.DataAnnotations;
namespace PruebaTecnicaLAFISE.DTOs
{

    public class DepositoDTO
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Monto { get; set; }
    }
}