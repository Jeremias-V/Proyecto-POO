using System;
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
    public class ActualizarUsuarioController : Controller
    {
        #region Properties
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public ActualizarUsuarioController(IMemoryCache memoryCache){
            _cache = memoryCache;
        }
        #endregion
        
        [HttpGet("")]
        public IActionResult ActualizarInfo(){
            try{
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                return Content(cacheEntry);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}