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
    public class RegistroController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public RegistroController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion
        [HttpPost("")]
        public async Task<IActionResult> Registrarse(UsuarioModel user){
            try
            {
                var usuarios = await dBContext.Usuarios.ToListAsync();
                if(usuarios.FirstOrDefault(users => users.Username == user.Username) == null){
                    dBContext.Usuarios.Add(user);
                    await dBContext.SaveChangesAsync();
                    return Redirect("/InicioSesion");
                }else{
                    return Content("Error, ese nombre de usuario no se encuentra disponible.");
                }
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }

        [HttpGet("")]
        public IActionResult Registrarse(){
            try
            {
                string cacheEntry = "";
                if (_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
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