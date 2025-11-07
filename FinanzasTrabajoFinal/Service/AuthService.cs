using Microsoft.EntityFrameworkCore;
using BCrypt.Net;

// 1. IMPORTANTE: Asegúrate de que el namespace coincida con tu proyecto y la carpeta.
namespace FinanzasTrabajoFinal.Service
{
    public class AuthService
    {
        private readonly FinanzasContext _context;

        public AuthService(FinanzasContext context)
        {
            _context = context;
        }

        public async Task<Usuarios> LoginAsync(string nombreUsuario, string contrasena)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);

            if (usuario == null)
            {
                return null; // Usuario no encontrado
            }

            if (BCrypt.Net.BCrypt.Verify(contrasena, usuario.ContraHash))
            {
                return usuario; // Login exitoso
            }

            return null; // Contraseña incorrecta
        }

        // --- ¡MÉTODO ACTUALIZADO! ---
        // Ahora devuelve un 'AuthResult' para que podamos manejar errores (ej. "Usuario ya existe")
        public async Task<AuthResult> RegisterAsync(string nombreUsuario, string contrasena)
        {
            // 1. Verificar si el usuario ya existe
            if (await _context.Usuarios.AnyAsync(u => u.NombreUsuario == nombreUsuario))
            {
                return new AuthResult { Success = false, ErrorMessage = "El nombre de usuario ya está en uso." };
            }

            // 2. Hashear la contraseña
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(contrasena);

            var nuevoUsuario = new Usuarios
            {
                NombreUsuario = nombreUsuario,
                ContraHash = passwordHash,
                FechaCreacion = DateTime.Now
            };

            try
            {
                // 3. Guardar en la DB
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();
                return new AuthResult { Success = true }; // ¡Éxito!
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error de la DB
                return new AuthResult { Success = false, ErrorMessage = ex.Message };
            }
        }
    }

    // Clase "ayudante" para el resultado del registro
    // (Puedes poner esta clase al final del archivo AuthService.cs)
    public class AuthResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}
