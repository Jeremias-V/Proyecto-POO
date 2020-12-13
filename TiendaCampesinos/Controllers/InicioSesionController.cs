using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCampesinos.Services;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class InicioSesionController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public InicioSesionController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion
        
        [HttpGet("")]
        public IActionResult IniciarSesion(){
            try{
                string cacheEntry = "";
                if (_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/MostrarProductos");
                }
                return View();
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }

        [HttpPost("")]
        public async Task<IActionResult> IniciarSesion(string Username, string Password){
            try
            {
                var users = await dBContext.Usuarios.ToListAsync();
                if(users.FirstOrDefault(user => user.Username == Username) != null){
                    if(users.FirstOrDefault(user => user.Password == Password) != null){

                        var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromMinutes(10));
                        _cache.Set("SesionIniciada", Username, cacheEntryOptions);
                        return Redirect("/MostrarProductos");

                    }else{
                        return Content("Nombre de usuario o contraseña incorrecto.");
                    }
                }else{
                    return Content("Nombre de usuario o contraseña incorrecto.");
                }
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}