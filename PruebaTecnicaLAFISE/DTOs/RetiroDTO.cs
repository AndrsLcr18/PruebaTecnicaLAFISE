using System.ComponentModel.DataAnnotations;
namespace PruebaTecnicaLAFISE.DTOs
{
    public class RetiroDTO
    {   // Monto a retirar de la cuenta
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a cero.")]
        public decimal Monto { get; set; }
    }
}