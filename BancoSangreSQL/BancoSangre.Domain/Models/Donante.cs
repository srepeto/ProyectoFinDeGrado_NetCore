using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSangre.Domain.Models
{
    [Table("donantes", Schema = "bancosangredb")]
    public class Donante
    {
        [Key]
        public string Dni { get; set; }

        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Gruposanguineo { get; set; }
        public string Factorrh { get; set; }

        [ForeignKey("Donantefk")]
        public ICollection<Donacion> Donaciones { get; set; }

        public Donante() { }

        public Donante(string dni, string nombre, string direccion, string telefono, DateTime fechaNacimiento, string gruposanguineo, string factorrh)
        {
            Dni = dni;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Gruposanguineo = gruposanguineo;
            Factorrh = factorrh;
        }

    }
}
