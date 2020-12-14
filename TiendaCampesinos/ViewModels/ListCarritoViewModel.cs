using System.Collections.Generic;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.ViewModels
{
    public class ListCarritoViewModel
    {
        public List<(CarritoComprasModel, ProductoModel)> CarritoProducto { get; set; }

        public ListCarritoViewModel()
        {
            CarritoProducto = new List<(CarritoComprasModel, ProductoModel)>();
        }
    }
}