using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoSangre.Domain.Models
{
    [Table("donaciones", Schema = "bancosangredb")]
    public class Donacion
    {
        [Key]
        public string Id { get; set; }

        public Donante Donante { get; set; }
        public string Donantefk { get; set; }

        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        public Donacion() { }

        public Donacion(string id, string donantefk, DateTime fecha, int cantidad)
        {
            Id = id;
            Donantefk = donantefk;
            Fecha = fecha;
            Cantidad = cantidad;
        }

    }
}
