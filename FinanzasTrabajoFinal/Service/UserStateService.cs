using FinanzasTrabajoFinal.MODELS; // <--- IMPORTANTE: Necesario para reconocer AnalisisFinanciero

namespace FinanzasTrabajoFinal.Service
{
    public class UserStateService
    {
        // El usuario actual. Es 'null' si nadie ha iniciado sesión.
        public Usuarios? CurrentUser { get; private set; }

        // === NUEVO: Propiedad para guardar el análisis y compartirlo entre páginas ===
        public AnalisisFinanciero? AnalisisRealizado { get; private set; }

        // Un evento que se dispara cuando el estado cambia.
        public event Action? OnChange;

        public bool IsLoggedIn => CurrentUser != null;

        public void LoginUser(Usuarios user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public void LogoutUser()
        {
            CurrentUser = null;
            AnalisisRealizado = null; // Limpiamos el análisis al cerrar sesión
            NotifyStateChanged();
        }

        // === NUEVO: Método para guardar el análisis (úsalo en Upload o Resultados) ===
        public void SetAnalisis(AnalisisFinanciero analisis)
        {
            AnalisisRealizado = analisis;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}