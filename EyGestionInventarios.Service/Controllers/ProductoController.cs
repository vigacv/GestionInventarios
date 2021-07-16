using EyGestionInventarios.Service.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EyGestionInventarios.Service.Controllers
{
    [ApiController]
    [EnableCors("MyAppPolicy")]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ProductoController> _logger;
        private readonly EyInventariosContext _context;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
            _context = new EyInventariosContext();
        }

        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            return _context.Productos.ToList();
        }

        [HttpPost]
        public string Post([FromBody] Producto producto)
        {
            Response response = new Response();
            try
            {
                _context.Productos.Add(producto);
                _context.SaveChanges();

                response.Estado = "Success";
                response.Mensaje = "Producto guardado exitosamente.";
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response.Estado = "Failure";
                response.Mensaje = "Error al insertar producto";
                if (ex.InnerException != null)
                {
                    response.Error = ex.InnerException.Message;
                }
                else
                {
                    response.Error = ex.Message;
                }
                
                return JsonSerializer.Serialize(response);
            }
        }

        [HttpPut("/producto/{cod}")]
        
        public string Put([FromBody] Producto producto, string cod)
        {
            Response response = new Response();
            
            try
            {
                IQueryable<Producto> result = _context.Productos.Where(p => p.CodArt == cod);
                Producto prodActual = result.First();
                prodActual.CodArt = producto.CodArt;
                prodActual.Nombre = producto.Nombre;
                prodActual.DescArt = producto.DescArt;
                prodActual.Cant = producto.Cant;
                _context.SaveChanges();

                response.Estado = "Success";
                response.Mensaje = "Producto con codigo " + cod + " modificado correctamente";
                return JsonSerializer.Serialize(response);
            }
            catch(Exception ex)
            {
                response.Estado = "Failure";
                response.Mensaje = "Error al actualizar producto";
                if (ex.InnerException != null)
                {
                    response.Error = ex.InnerException.Message;
                }
                else
                {
                    response.Error = ex.Message;
                }
                return JsonSerializer.Serialize(response);
            }
        }

        [HttpDelete("/producto/{cod}")]
        public string Delete(string cod)
        {
            Response response = new Response();
            try
            {
                Producto prodActual = _context.Productos.Where(p => p.CodArt == cod).First();
                _context.Productos.Remove(prodActual);
                _context.SaveChanges();

                response.Estado = "Success";
                response.Mensaje = "Producto con codigo " + cod + " borrado.";
                return JsonSerializer.Serialize(response);
            }
            catch (Exception ex)
            {
                response.Estado = "Failure";
                response.Mensaje = "Error al borrar producto" ;
                if (ex.InnerException != null)
                {
                    response.Error = ex.InnerException.Message;
                }
                else
                {
                    response.Error = ex.Message;
                }
                return JsonSerializer.Serialize(response);
            }
        }
    }
}
