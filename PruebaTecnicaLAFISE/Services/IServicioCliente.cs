using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;

namespace PruebaTecnicaLAFISE.Services
{
    public interface IServicioCliente
    {
        // Interfaz para el servicio de cliente CrearClienteAsync y GetClienteAsync
        Task<Cliente> CrearClienteAsync(ClienteDTO clientDto);

        Task<IActionResult> GetClienteAsync(long id);
    }
}
