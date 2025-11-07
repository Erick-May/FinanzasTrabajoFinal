namespace FinanzasTrabajoFinal.Service
{
    public class UserStateService
    {
        // El usuario actual. Es 'null' si nadie ha iniciado sesión.
        public Usuarios? CurrentUser { get; private set; }

        // Un evento que se dispara cuando el estado del usuario cambia.
        public event Action? OnChange;

        // Propiedad para saber si hay alguien logueado
        public bool IsLoggedIn => CurrentUser != null;

        // Método que se llama desde Login.razor
        public void LoginUser(Usuarios user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        // Método que se llama desde Logout.razor
        public void LogoutUser()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        // Este método es el que "avisa" al NavMenu y al Home que deben refrescarse
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
