using System;
using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class VentasModel{

        [Key]
        public long Id { get; set; }
        public long IdCampesino { get; set; }
        public long IdProducto { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public DateTime Fecha { get; set; }

        public VentasModel(){}

        public VentasModel(long idcamp, long idprod, int cant, int precio){
            IdCampesino = idcamp;
            IdProducto = idprod;
            Cantidad = cant;
            Precio = precio;
            Fecha = DateTime.Now;
        }
    }
    

}