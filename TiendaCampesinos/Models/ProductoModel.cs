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

        public ProductoModel(long id, string name, string img, int peso, int precio, int cantidad){
            IdCampesino = id;
            NombreProducto = name;
            Imagen = img;
            PesoNeto = peso;
            Precio = precio;
            Cantidad = cantidad;
        }

        public ProductoModel(){}

    }
    

}