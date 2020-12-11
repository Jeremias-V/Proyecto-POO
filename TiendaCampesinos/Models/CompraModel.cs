using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class CompraModel{

        [Key]
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public long IdProducto { get; set; }
        public string MetodoPago { get; set; }
        public int Cantidad { get; set;}
        public DateTime Fecha { get; set; }

    }
    

}