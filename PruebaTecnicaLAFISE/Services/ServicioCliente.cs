using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.Data;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;
using System.Security.Cryptography;

namespace PruebaTecnicaLAFISE.Services
{

    public class ServicioCliente : IServicioCliente
    {
        // Inyección de dependencias para el contexto de la base de datos y el mapeador
        private readonly LAFISEDbContext _context;
        private readonly IMapper _mapper;

        // Constructor que recibe solo el contexto de la base de datos
        public ServicioCliente(LAFISEDbContext context)
        {
            _context = context;
        }

        // Constructor que recibe el contexto de la base de datos y el mapeador
        public ServicioCliente(LAFISEDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Método para crear un nuevo cliente
        public async Task<Cliente> CrearClienteAsync(ClienteDTO clientDto)
        {
            // Mapear DTO a modelo
            var cliente = _mapper.Map<Cliente>(clientDto);

            // Generar ID único utilizando un método uxiliar
            long id = GenerateUniqueId();
            cliente.Id = id;

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        // Método para consultar un cliente por ID
        public async Task<IActionResult> GetClienteAsync(long id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Cuentas)
                .FirstOrDefaultAsync(c => c.Id == Convert.ToInt64(id.ToString()));

            if (cliente == null)
                return new NotFoundResult(); //  devolver un 404

            return new OkObjectResult(cliente); //  devolver el cliente mapeado
   
        }

        // Método auxiliar para generar un ID único
        private long GenerateUniqueId()
        {
            byte[] buffer = new byte[8];
            RandomNumberGenerator.Fill(buffer);
            return BitConverter.ToInt64(buffer, 0) & long.MaxValue; // Asegurar que el número sea positivo
        }

    }
}
