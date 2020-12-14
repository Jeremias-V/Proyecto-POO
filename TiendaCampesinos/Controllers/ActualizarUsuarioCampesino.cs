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
    public class ActualizarUsuarioCampesinoController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public ActualizarUsuarioCampesinoController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion
        
        [HttpGet("")]
        public async Task<IActionResult> ActualizarInfoCampesino(){
            try{
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                var users = await dBContext.Usuarios.ToListAsync();
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                UsuarioModel user = await dBContext.Usuarios.FindAsync(id);
                return View(user);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }

        [HttpPost("")]
        public async Task<IActionResult> ActualizarInfo(UsuarioModel Usuario)
        {
            try
            {
                dBContext.Entry(Usuario).State = EntityState.Modified;
                await dBContext.SaveChangesAsync();
                return Redirect("/MostrarProductosCampesino");
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}