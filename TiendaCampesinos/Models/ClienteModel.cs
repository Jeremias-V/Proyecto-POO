using System;
using System.Collections.Generic;

namespace TiendaCampesinos.Models
{

    public class ClienteModel : UsuarioModel{

        public List<Tuple<long, int>> IdsCarritoCompras { get; set; } // Lista de productos donde cada elemento es una tupla y el primer elemento es el id del producto, el segundo elemento es la cantidad del producto.
        public List<long> IdsHistorialCompras { get; set; } // Lista de ids donde cada id es una compra
    
    }
    

}