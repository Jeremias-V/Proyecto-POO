using System.Collections.Generic;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.ViewModels
{
    public class ListCompraViewModel
    {
        public List<(CompraModel, ProductoModel)> CompraProducto { get; set; }

        public ListCompraViewModel()
        {
            CompraProducto = new List<(CompraModel, ProductoModel)>();
        }
    }
}