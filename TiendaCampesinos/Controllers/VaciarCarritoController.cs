using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using TiendaCampesinos.Services;

namespace TiendaCampesinos.Controllers
{
    [Route("[controller]")]
    public class VaciarCarritoController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public VaciarCarritoController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion

        [HttpGet("")]
        public async Task<IActionResult> VaciarCarrito(){
            try{
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                var users = await dBContext.Usuarios.ToListAsync();
                var usr = users.FirstOrDefault(user => user.Username == cacheEntry);
                if(usr.TipoUsuario == "Campesino"){
                    return Redirect("/MostrarProductosCampesino");
                }
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                var listaCarrito = await dBContext.CarritoCompras.Where(usr => usr.IdUsuario == id).ToListAsync();
                foreach (var item in listaCarrito)
                {
                    var productoCorrespondiente = dBContext.Productos.FirstOrDefault(compra => compra.Id == item.IdProducto);
                    productoCorrespondiente.Cantidad += item.Cantidad;
                    dBContext.CarritoCompras.Remove(item);
                }
                await dBContext.SaveChangesAsync();
                return Redirect("/MostrarCarrito");
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}