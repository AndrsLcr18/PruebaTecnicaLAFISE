using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;
using PruebaTecnicaLAFISE.Services;
using System.Security.Cryptography;

namespace PruebaTecnicaLAFISE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController (IServicioCliente _servicioCliente) : ControllerBase 
    {
        // POST: api/clientes
        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteDTO clientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Cliente cliente = await _servicioCliente.CrearClienteAsync(clientDto);

            return CreatedAtAction(nameof(GetClientesById), new { id = cliente.Id }, cliente);
        }


        // GET: api/clientes/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientesById(Int64 id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _servicioCliente.GetClienteAsync(id);
        }


    }
}
