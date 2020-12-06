using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class Paypal{

        [Key]
        public long Id { get; set; }
        public string CorreoElectronicoPaypal { get; set; }

    }
    

}