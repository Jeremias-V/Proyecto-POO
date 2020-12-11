using System.Collections.Generic;
using TiendaCampesinos.Models;
using TiendaCampesinos.Services;

namespace TiendaCampesinos.ViewModels
{
    public class ListProductViewModel
    {
        public List<ProductoModel> Productos { get; set; }

        public ListProductViewModel()
        {
            Productos = new List<ProductoModel>();
        }
    }
}