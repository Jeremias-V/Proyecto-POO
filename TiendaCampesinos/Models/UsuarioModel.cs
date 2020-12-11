using System.ComponentModel.DataAnnotations;

namespace TiendaCampesinos.Models
{

    public class UsuarioModel{

        [Key]
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TipoUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string NumeroIdentificacion { get; set; }
        public string CorreoPaypal { get; set; }
        public string NumeroTC { get; set; }
        public string FechaCaducidadTC { get; set; }
        public string NombreEnTC { get; set; }
        public string CVV { get; set; }
        public string IdentificacionAsociadaCA { get; set; }
        public string NumeroCA { get; set; }
        public string Departamento { get; set; }
        public string Municipio { get; set; }
        public string Direccion { get; set; }

    }
    

}