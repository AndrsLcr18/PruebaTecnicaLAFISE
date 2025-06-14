using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;

namespace PruebaTecnicaLAFISE.Services
{
    public interface IServicioCliente
    {
        Task<Cliente> CrearClienteAsync(ClienteDTO clientDto);

        Task<IActionResult> GetClienteAsync(long id);
    }
}
