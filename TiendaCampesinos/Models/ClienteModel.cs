using System;
using System.Collections.Generic;

namespace TiendaCampesinos.Models
{

    public class Cliente : Usuario{

        public List<Tuple<long, int>> IdsCarritoCompras{ get; set; }
        public List<long> IdsHistorialCompras;
    
    }
    

}