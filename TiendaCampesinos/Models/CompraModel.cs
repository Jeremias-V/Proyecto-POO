using System;
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
        public int Precio { get; set;}
        public DateTime Fecha { get; set; }

        public CompraModel(){}
        public CompraModel(long idcliente, long idproducto, string metodopago, int cantidad, int precio){
            IdCliente = idcliente;
            IdProducto = idproducto;
            MetodoPago = metodopago;
            Cantidad = cantidad;
            Precio = precio;
            Fecha = DateTime.Now;
        }

    }

}