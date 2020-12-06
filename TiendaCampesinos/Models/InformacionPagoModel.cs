using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class InformacionPago{

        [Key]
        public long Id { get; set; }
        public long IdTarjetaCredito { get; set; }
        public long IdPaypal { get; set; }
        public long IdCuentaAhorros { get; set; }

    }
    

}