using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class InformacionPagoModel{

        [Key]
        public long Id { get; set; }
        public long IdTarjetaCredito { get; set; }
        public string CorreoPaypal { get; set; }
        public long IdCuentaAhorros { get; set; }

    }
    

}