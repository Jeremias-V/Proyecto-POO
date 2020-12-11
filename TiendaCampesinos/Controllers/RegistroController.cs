using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class RegistroController : Controller
    {
        #region test
        private readonly TiendaCampesinosDBContext dBContext;
        public RegistroController(TiendaCampesinosDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        [HttpGet("")]
        public async Task<IActionResult> Registrarse(){
            try{
                List<ProductoModel> productos = await dBContext.Productos.ToListAsync();
                return View();
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}