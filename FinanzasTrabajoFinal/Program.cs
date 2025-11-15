using FinanzasTrabajoFinal.Components;
using FinanzasTrabajoFinal.Service;
using Microsoft.EntityFrameworkCore; // <-- Asegúrate que esté este 'using'

// 1. Registra esto al inicio
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

// 2. Creas el builder UNA SOLA VEZ
var builder = WebApplication.CreateBuilder(args);

// --- 3. REGISTRA TODOS TUS SERVICIOS AQUÍ ---

// Lee la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'. Revisa tu appsettings.json.");

// **** ¡ESTA ES LA LÍNEA QUE ARREGLA TODO! ****
// Esto registra AMBOS: la Fábrica (IDbContextFactory) Y el Contexto (FinanzasContext)
builder.Services.AddDbContextFactory<FinanzasContext>(options =>
    options.UseSqlServer(connectionString));

// Registra tus otros servicios
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<GeminiService>();

// Registra los componentes de Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// --- 4. NO HAY MÁS CÓDIGO HASTA EL builder.Build() ---

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();