using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;
using System.Linq;
using System.Net;  


namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class InicioSesionController : Controller
    {
        #region test
        private readonly TiendaCampesinosDBContext dBContext;
        public InicioSesionController(TiendaCampesinosDBContext dBContext){
            this.dBContext = dBContext;
        }
        #endregion
        [HttpGet("")]
        public IActionResult IniciarSesion(){
            try{
                return View();
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }

        [HttpPost("")]
        public async Task<IActionResult> IniciarSesion(string Username, string Password){
            try{
                var users = await dBContext.Usuarios.ToListAsync();
                if(users.FirstOrDefault(user => user.Username == Username) != null){
                    if(users.FirstOrDefault(user => user.Password == Password) != null){
                        return Ok("Bienvenido " + Username);
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