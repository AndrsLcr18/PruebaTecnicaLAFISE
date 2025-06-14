using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Services;

namespace PruebaTecnicaLAFISE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentasController(IServicioCuenta _servicioCuenta) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CrearCuenta([FromBody] CrearCuentaDTO cuentaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _servicioCuenta.CrearCuentaAsync(cuentaDTO.IdCliente, cuentaDTO.SaldoInicial);
                return Ok("Cuenta creada exitosamente.");
            }
            catch (Exception ex)
            {
                // Aquí puedes agregar logging del error, si tienes configurado
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("{numeroCuenta}/saldo")]
        public async Task<IActionResult> GetSaldo(string numeroCuenta)
        {
            if (string.IsNullOrWhiteSpace(numeroCuenta))
                return BadRequest("El número de cuenta es requerido.");

            var saldo = await _servicioCuenta.GetSaldoAsync(numeroCuenta);

            if (saldo == null)
                return NotFound($"No se encontró la cuenta con número {numeroCuenta}.");

            return Ok(new { NumeroCuenta = numeroCuenta, Saldo = saldo });
        }

        [HttpPost("{numeroCuenta}/deposito")]
        public async Task<IActionResult> Deposito(string numeroCuenta, [FromBody] DepositoDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _servicioCuenta.DepositoAsync(numeroCuenta, dto.Monto);

            if (!ModelState.IsValid)  // Asumo que resultado tiene una propiedad para indicar éxito
                return BadRequest(resultado.Mensaje);

            return Ok(resultado);
        }

        [HttpPost("{numeroCuenta}/retiro")]
        public async Task<IActionResult> Retiro(string numeroCuenta, [FromBody] RetiroDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var resultado = await _servicioCuenta.RetiroAsync(numeroCuenta, dto.Monto);

            if (!ModelState.IsValid)  // Igual aquí
                return BadRequest(resultado.Mensaje);

            return Ok(resultado);
        }

        [HttpGet("{numeroCuenta}/transacciones")]
        public async Task<IActionResult> GetTransacciones(string numeroCuenta)
        {
            var transacciones = await _servicioCuenta.GetTransaccionesAsync(numeroCuenta);
            if (transacciones == null)
                return NotFound("Cuenta no encontrada.");

            return Ok(transacciones);
        }
    }
}