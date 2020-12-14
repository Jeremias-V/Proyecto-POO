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
                var usr = users.FirstOrDefault(user => user.Username == cacheEntry);
                if(usr.TipoUsuario == "Campesino"){
                    return Redirect("/MostrarProductosCampesino");
                }
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

        [HttpPost("")]
        public async Task<IActionResult> ComprarCarrito(CompraModel compra){
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
                List<CarritoComprasModel> carritoAsociado = await dBContext.CarritoCompras.ToListAsync();
                carritoAsociado = carritoAsociado.Where(carrito => carrito.IdUsuario == id).ToList();
                var productosAsociados = await dBContext.Productos.ToListAsync();
                foreach (var item in carritoAsociado)
                {
                    ProductoModel tmp = productosAsociados.First(prod => prod.Id == item.IdProducto);
                    CompraModel tmp2  = new CompraModel(id, tmp.Id, compra.MetodoPago, item.Cantidad, tmp.Precio);
                    dBContext.Compras.Add(tmp2);
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