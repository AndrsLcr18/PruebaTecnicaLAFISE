using Microsoft.EntityFrameworkCore;
using PruebaTecnicaLAFISE.DTOs;
using PruebaTecnicaLAFISE.Models;
using System.Collections.Generic;
using System.Security.Principal;
using System.Transactions;

namespace PruebaTecnicaLAFISE.Data
{
    public class LAFISEDbContext : DbContext
    {
            // Constructor que recibe las opciones de configuración del contexto
            public LAFISEDbContext(DbContextOptions<LAFISEDbContext> options) : base(options) { }
            
            // Propiedades DbSet para las entidades del modelo de datos
            public DbSet<Cliente> Clientes => Set<Cliente>();
            public DbSet<Cuenta> Cuentas => Set<Cuenta>();
            public DbSet<Transaccion> Transacciones => Set<Transaccion>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Cliente - Cuenta (Un cliente tiene muchas cuentas)
            modelBuilder.Entity<Cuenta>()
                .HasOne(c => c.Cliente)
                .WithMany(cl => cl.Cuentas)
                .HasForeignKey(c => c.ClienteId)
                .OnDelete(DeleteBehavior.Cascade); // Ajusta según tu lógica de negocio

            // Relación Cuenta - Transaccion (Una cuenta tiene muchas transacciones)
            modelBuilder.Entity<Transaccion>()
                .HasOne(t => t.Cuenta)
                .WithMany(c => c.Transacciones)
                .HasForeignKey(t => t.CuentaId)
                .OnDelete(DeleteBehavior.Restrict); // Evita eliminar una cuenta con transacciones

            base.OnModelCreating(modelBuilder);
        }

    }
}
