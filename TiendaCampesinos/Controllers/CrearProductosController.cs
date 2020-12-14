using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class CrearProductosController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public CrearProductosController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion
        [HttpPost("")]
        public async Task<IActionResult> CrearProducto(string NombreProducto, string Imagen, int PesoNeto, int Precio, int Cantidad){
            try
            {
                string cacheEntry = "";
                _cache.TryGetValue("SesionIniciada", out cacheEntry);
                var users = await dBContext.Usuarios.ToListAsync();
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                ProductoModel producto = new ProductoModel(id, NombreProducto, Imagen, PesoNeto, Precio, Cantidad);
                dBContext.Productos.Add(producto);
                await dBContext.SaveChangesAsync();
                return Redirect("/MostrarProductos");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> CrearProducto(){
            try
            {
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                var users = await dBContext.Usuarios.ToListAsync();
                var usr = users.FirstOrDefault(user => user.Username == cacheEntry);
                if(usr.TipoUsuario != "Campesino"){
                    return Redirect("/MostrarProductos");
                }
                return View();
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
        
    }
}