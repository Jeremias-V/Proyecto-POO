using System;
using System.Collections.Generic;

namespace TiendaCampesinos.Models
{

    public class CampesinoModel : UsuarioModel{

        public List<Tuple<long, int>> IdsProductos { get; set; } // Lista de productos donde cada elemento es una tupla y el primer elemento es el id del producto, el segundo elemento es la cantidad del producto.    
    }
    

}