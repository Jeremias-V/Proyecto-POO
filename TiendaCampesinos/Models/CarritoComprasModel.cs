using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class CarritoComprasModel{

        [Key]
        public long Id { get; set; }
        public long IdProducto { get; set; }
        public long IdUsuario { get; set; }
        public int Cantidad { get; set;}

    }
    

}