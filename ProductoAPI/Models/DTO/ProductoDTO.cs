using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Models.DTO
{
    public class ProductoDTO
    {
      
        public int id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public byte[] imagen { get; set; }
        public double rating { get; set; }
    }
}
