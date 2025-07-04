﻿using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace PruebaTecnicaLAFISE.Models
{
    public class Cliente
    {
        //Identificador único del cliente
        [Required]
        public Int64 Id { get; set; } 
       
        //nombre del cliente
        [Required]
        public string Nombre { get; set; } = null!; 
        
        //dia de nacimiento del cliente
        [Required]
        public DateTime Nacimiento { get; set; } 
        
        //Sexo del cliente, podría ser "Masculino", "Femenino", etc.
        [Required]
        [RegularExpression("H|M|O", ErrorMessage = "Genero debe ser H, M o O (Otro)")]
        public required string Genero { get; set; }  
        
        //Ingreso mensual del cliente
        [Required]
        [Range(0, double.MaxValue)]
        public decimal Ingreso { get; set; }

        // diccionario de cuentas asociadas al cliente
        [JsonIgnore] 
        public ICollection<Cuenta> Cuentas { get; set; } = new List<Cuenta>(); 
    }
}
