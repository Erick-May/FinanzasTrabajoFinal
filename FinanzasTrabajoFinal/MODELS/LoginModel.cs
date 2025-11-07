using System.ComponentModel.DataAnnotations;

namespace FinanzasTrabajoFinal.MODELS
{

    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public string NombreUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)] // Para ocultar la entrada en la UI
        public string Contrasena { get; set; }
    }
}
