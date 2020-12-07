using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class CompraModel{

        [Key]
        public long Id { get; set; }
        public List<Tuple<long, int>> ProductosComprados { get; set; }
        public DateTime Fecha { get; set; }
        public string MetodoPago { get; set; }

    }
    

}