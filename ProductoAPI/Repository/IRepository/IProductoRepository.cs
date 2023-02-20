using ProductoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Repository.IRepository
{
    public interface IProductoRepository
    {
        IEnumerable<Producto> GetAllProducto();
        Producto GetProducto(int id);
        bool ProductoExiste(string nombre);
        bool ProductoExiste(int id);

        bool CrearProducto(Producto producto);
        bool ActualizarProducto(Producto producto);
        bool EliminarProducto(Producto producto);
        bool Guardar();

    }
}
