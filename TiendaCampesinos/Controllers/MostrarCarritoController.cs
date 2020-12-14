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
    public class MostrarCarritoController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public MostrarCarritoController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion

        [HttpGet("")]
        public async Task<IActionResult> ListaCarrito(){
            ListCarritoViewModel vm = new ListCarritoViewModel();
            try{
                string cacheEntry = "";
                if (!_cache.TryGetValue("SesionIniciada", out cacheEntry))
                {
                    return Redirect("/");
                }
                var users = await dBContext.Usuarios.ToListAsync();
                long id = users.FirstOrDefault(user => user.Username == cacheEntry).Id;
                List<CarritoComprasModel> carritoAsociado = await dBContext.CarritoCompras.ToListAsync();
                carritoAsociado = carritoAsociado.Where(carrito => carrito.IdUsuario == id).ToList();
                List<(CarritoComprasModel, ProductoModel)> construirLista = new List<(CarritoComprasModel, ProductoModel)>();
                var productosAsociados = await dBContext.Productos.ToListAsync();
                foreach (var item in carritoAsociado)
                {
                    ProductoModel tmp = productosAsociados.First(prod => prod.Id == item.IdProducto);
                    (CarritoComprasModel, ProductoModel) tmp2 = Tuple.Create(item, tmp).ToValueTuple();
                    construirLista.Add(tmp2);
                }
                vm.CarritoProducto = construirLista;
                return View(vm);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}