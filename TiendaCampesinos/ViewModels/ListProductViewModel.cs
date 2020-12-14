using System.Collections.Generic;
using TiendaCampesinos.Models;

namespace TiendaCampesinos.ViewModels
{
    public class ListProductViewModel
    {
        public List<ProductoModel> Productos { get; set; }
        public ProductoModel producto { get; set; }

        public ListProductViewModel()
        {
            Productos = new List<ProductoModel>();
            producto = new ProductoModel();
        }
    }
}