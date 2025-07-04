﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PruebaTecnicaLAFISE.Data;

#nullable disable

namespace PruebaTecnicaLAFISE.Migrations
{
    [DbContext(typeof(LAFISEDbContext))]
    [Migration("20250613164222_UpdateModel_LAFISE")]
    partial class UpdateModel_LAFISE
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.6");

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Ingreso")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Nacimiento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Cuenta", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("IdCliente")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NumeroCuenta")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Transaccion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("CuentaId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("DisponibleDepuesTransaccion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<long>("IdCuenta")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mensaje")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tipo")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Transacciones");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Cuenta", b =>
                {
                    b.HasOne("PruebaTecnicaLAFISE.Models.Cliente", "Cliente")
                        .WithMany("Cuentas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Transaccion", b =>
                {
                    b.HasOne("PruebaTecnicaLAFISE.Models.Cuenta", "Cuenta")
                        .WithMany("Transacciones")
                        .HasForeignKey("CuentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuenta");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Cliente", b =>
                {
                    b.Navigation("Cuentas");
                });

            modelBuilder.Entity("PruebaTecnicaLAFISE.Models.Cuenta", b =>
                {
                    b.Navigation("Transacciones");
                });
#pragma warning restore 612, 618
        }
    }
}
