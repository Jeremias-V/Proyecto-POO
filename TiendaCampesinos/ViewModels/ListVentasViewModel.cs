using System.Collections.Generic;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.ViewModels
{
    public class ListVentasViewModel
    {
        public List<(VentasModel, ProductoModel)> VentaProducto { get; set; }

        public ListVentasViewModel()
        {
            VentaProducto = new List<(VentasModel, ProductoModel)>();
        }
    }
}