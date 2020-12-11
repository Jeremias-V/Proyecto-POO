
namespace TiendaCampesinos.Models
{

    public class DatosUsuarioModel{

        public UsuarioModel Usuario {get; set;}
        public InformacionBasicaModel InfoBasica {get; set;}
        public InformacionPagoModel InfoPago {get; set;}
        public DireccionModel InfoDomicilio {get; set;}
        public TarjetaCreditoModel TC {get; set;}
        public CuentaAhorroModel CA {get; set;}
        
        

    }
    

}