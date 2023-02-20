using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductoAPI.Models;
using ProductoAPI.Models.DTO;
using ProductoAPI.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository productoRepository;
        private readonly IMapper mapper;

        public ProductoController(IProductoRepository productoRepository, IMapper mapper)
        {
            this.productoRepository = productoRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProductos() 
        {
            var producto = productoRepository.GetAllProducto();
            return Ok(mapper.Map<List<ProductoDTO>>(producto));
        }

        [HttpGet("{id}", Name ="GetProducto")]
        public IActionResult GetProducto(int id)
        {
            var producto = productoRepository.GetProducto(id);
            if (producto == null) return NotFound();
            return Ok(mapper.Map<ProductoDTO>(producto));
        }

        [HttpPost]
        public IActionResult CrearProducto([FromBody] ProductoDTO productoDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (productoRepository.ProductoExiste(productoDTO.nombre))
            {
                ModelState.AddModelError(string.Empty, $"Ya existe el producto con el nombre {productoDTO.nombre} ");
                return StatusCode(404, ModelState);
            }

            var producto = mapper.Map<Producto>(productoDTO);
            if (!productoRepository.CrearProducto(producto))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar guardar el producto {productoDTO.nombre}");
                return StatusCode(500, ModelState);
            }

            return CreatedAtRoute("GetProducto", new { id = producto.id }, producto);

        }

        [HttpPut("{id}")]
        public IActionResult ActualizarProducto(int id, [FromBody] ProductoDTO productoDTO)
        {
            if (id != productoDTO.id) return BadRequest(ModelState);
            var producto = mapper.Map<Producto>(productoDTO);
            if (!productoRepository.ActualizarProducto(producto))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurrido un error al intentar actualizar el producto {productoDTO.nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarProducto(int id)
        {
            if (!productoRepository.ProductoExiste(id)) return NotFound();
            var producto = productoRepository.GetProducto(id);

            if (!productoRepository.EliminarProducto(producto))
            {
                ModelState.AddModelError(string.Empty, $"Ha ocurido un error al intentar eliminar el producto {producto.nombre}");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

    }
}
