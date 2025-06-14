namespace PruebaTecnicaLAFISE.DTOs
{
    public class CuentaDTO
    { // Identificador único de la cuenta
        public required string NumeroCuenta { get; set; }
        // Identificador del cliente al que pertenece la cuenta
        public decimal Saldo { get; set; }
    }
}
