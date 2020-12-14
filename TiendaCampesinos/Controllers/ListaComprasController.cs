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
    public class ListaComprasController : Controller
    {
        #region Properties
        private readonly TiendaCampesinosDBContext dBContext;
        private IMemoryCache _cache;

        #endregion

        #region Constructor
        public ListaComprasController(TiendaCampesinosDBContext dBContext, IMemoryCache memoryCache){
            this.dBContext = dBContext;
            _cache = memoryCache;
        }
        #endregion

        [HttpGet("")]
        public async Task<IActionResult> ListaCompras(){
            ListCompraViewModel vm = new ListCompraViewModel();
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
                var comprasClienteActual = dBContext.Compras.Where(usr => usr.IdCliente == id);
                List<(CompraModel, ProductoModel)> construirLista = new List<(CompraModel, ProductoModel)>();
                var productosAsociados = await dBContext.Productos.ToListAsync();
                foreach (var item in comprasClienteActual)
                {
                    ProductoModel tmp = productosAsociados.First(prod => prod.Id == item.IdProducto);
                    (CompraModel, ProductoModel) tmp2 = Tuple.Create(item, tmp).ToValueTuple();
                    construirLista.Add(tmp2);
                }
                vm.CompraProducto = construirLista;
                return View(vm);
            }
            catch (Exception e){
                return Content(e.Message);
            }
            
        }
    }
}