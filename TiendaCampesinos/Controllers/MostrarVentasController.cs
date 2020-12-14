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
    public class MostrarVentasController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public MostrarVentasController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion

        [HttpGet("")]
        public async Task<IActionResult> ListaVentas(){
            ListVentasViewModel vm = new ListVentasViewModel();
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
                List<VentasModel> ventasAsociadas = await dBContext.Ventas.ToListAsync();
                ventasAsociadas = ventasAsociadas.Where(ventas => ventas.IdCampesino == id).ToList();
                List<(VentasModel, ProductoModel)> construirLista = new List<(VentasModel, ProductoModel)>();
                var productosAsociados = await dBContext.Productos.ToListAsync();
                foreach (var item in ventasAsociadas)
                {
                    ProductoModel tmp = productosAsociados.First(prod => prod.Id == item.IdProducto);
                    (VentasModel, ProductoModel) tmp2 = Tuple.Create(item, tmp).ToValueTuple();
                    construirLista.Add(tmp2);
                }
                vm.VentaProducto = construirLista;
                return View(vm);
            }
            catch (Exception e){
                return Content(e.Message);
            }
        }
    }
}