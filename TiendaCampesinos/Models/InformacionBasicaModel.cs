using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class InformacionBasicaModel{

        [Key]
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string NumeroIdentificacion { get; set; }

    }
    

}