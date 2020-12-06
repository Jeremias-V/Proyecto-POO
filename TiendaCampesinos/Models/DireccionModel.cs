using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class Direccion{

        [Key]
        public long Id { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Calle { get; set; }
        public string Carrera { get; set; }
        public string Numeral { get; set; }
        public string TipoInmueble { get; set; }
        public string Detalles { get; set; }

    }
    

}