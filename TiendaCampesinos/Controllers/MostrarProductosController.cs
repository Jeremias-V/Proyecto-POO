using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;
using TiendaCampesinos.ViewModels;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class MostrarProductosController : Controller
    {
        #region test
        private readonly TiendaCampesinosDBContext dBContext;
        public MostrarProductosController(TiendaCampesinosDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        [HttpGet("")]
        public async Task<IActionResult> ListaProductos(){
            ListProductViewModel vm = new ListProductViewModel();
            try{
                vm.Productos = await dBContext.Productos.ToListAsync();
                return View(vm);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}