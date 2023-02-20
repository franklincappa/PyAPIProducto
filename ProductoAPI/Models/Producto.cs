using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Models
{
    public class Producto
    {
        public Producto()
        {
            fechaCreacion = DateTime.Now;
        }

        [Key]
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        [Required]
        public double precio { get; set; }
        public DateTime fechaCreacion { get; set; }
        public byte[] imagen { get; set; }
        public double rating { get; set; }

    }
}
