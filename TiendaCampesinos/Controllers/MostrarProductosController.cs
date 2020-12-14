using System;
using System.Collections.Generic;
using System.Linq;
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
    public class MostrarProductosController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public MostrarProductosController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion

        [HttpGet("")]
        public async Task<IActionResult> ListaProductos(){
            ListProductViewModel vm = new ListProductViewModel();
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
                vm.Productos = await dBContext.Productos.ToListAsync();
                return View(vm);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }

        [HttpPost("")]
        public async Task<IActionResult> ListaProductos(ProductoModel producto){
            try{
                /*
                Verificar si ya tiene agregado el id de producto, de ser asi unicamente modificar la cantidad
                en caso contrario agregar.

                Tener cuidado con agregar mas cantidad de la necesaria, restar cantidades si se agrega o sumar
                si se elimina.
                */
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                var users = await dBContext.Usuarios.ToListAsync();
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                CarritoComprasModel nuevaCompra = new CarritoComprasModel(producto.Id, id, producto.Cantidad);
                dBContext.CarritoCompras.Add(nuevaCompra);
                await dBContext.SaveChangesAsync();
                return Redirect("/MostrarProductos");
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}