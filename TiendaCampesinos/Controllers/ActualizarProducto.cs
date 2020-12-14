using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;
using TiendaCampesinos.ViewModels;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class ActualizarProductoController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public ActualizarProductoController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion
        
        [HttpGet("{idProducto}")]
        public async Task<IActionResult> ActualizarInfo(long idProducto){
            try{
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
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                var productos = await dBContext.Productos.ToListAsync();
                var tmp = productos.FirstOrDefault(prod => prod.Id == idProducto);
                if(tmp == null){
                    return Redirect("/MostrarProductosCampesino");
                }
                ProductoModel producto = tmp;
                if(producto.IdCampesino != id){
                    return Redirect("/MostrarProductosCampesino");
                }
                return View(producto);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }

        [HttpPost("{idProducto}")]
        public async Task<IActionResult> ActualizarInfo(ProductoModel Producto)
        {
            try
            {
                dBContext.Entry(Producto).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return Redirect("/MostrarProductos");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}