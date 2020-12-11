using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class DireccionModel{

        [Key]
        public long Id { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }
        public string Detalles { get; set; }

    }
    

}