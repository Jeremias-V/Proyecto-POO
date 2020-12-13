using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace TiendaCampesinos.Controllers
{
    public class HomeController : Controller
    {
        #region Properties
        private IMemoryCache _cache;

        #endregion

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            string cacheEntry = "";
            if (_cache.TryGetValue("SesionIniciada", out cacheEntry))
            {
                    return Redirect("/MostrarProductos");
            }
            return View();
        }
    }
}
