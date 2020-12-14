using System.Collections.Generic;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.ViewModels
{
    public class ListCarritoViewModel
    {
        public List<CarritoComprasModel> Carrito { get; set; }

        public ListCarritoViewModel()
        {
            Carrito = new List<CarritoComprasModel>();
        }
    }
}