using ProductoAPI.Context;
using ProductoAPI.Models;
using ProductoAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext context;
        public ProductoRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool ActualizarProducto(Producto producto)
        {
            context.Producto.Update(producto);
            return Guardar();
        }

        public bool CrearProducto(Producto producto)
        {
            context.Producto.Add(producto);
            return Guardar();
        }

        public bool EliminarProducto(Producto producto)
        {
            context.Producto.Remove(producto);
            return Guardar();
        }

        public IEnumerable<Producto> GetAllProducto()
        {
            return context.Producto.ToList();
        }

        public Producto GetProducto(int id)
        {
            return context.Producto.FirstOrDefault(x => x.id.Equals(id)); 
        }

        public bool Guardar()
        {
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool ProductoExiste(string nombre)
        {
            return context.Producto.Any(x => x.nombre.ToLower().Trim().Equals(nombre.ToLower().Trim()));
        }

        public bool ProductoExiste(int id)
        {
            return context.Producto.Any(x => x.id.Equals(id));
        }
    }
}
