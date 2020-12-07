using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class TarjetaCreditoModel{

        [Key]
        public long Id { get; set; }
        public string Numero { get; set; }
        public string FechaCaducidad { get; set; }
        public int CVV { get; set; }
        public string NombreEnTarjeta { get; set; }

    }
    

}