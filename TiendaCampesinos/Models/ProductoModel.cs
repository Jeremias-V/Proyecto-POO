using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class ProductoModel{

        [Key]
        public long Id { get; set; }
        public long IdCampesino { get; set; }
        public string NombreProducto { get; set; }
        public string Imagen { get; set; }
        public int PesoNeto { get; set; }
        public int Precio { get; set; }
        public int Cantidad { get; set; }

    }
    

}