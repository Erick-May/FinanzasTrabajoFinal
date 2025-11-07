using FinanzasTrabajoFinal.Components;
using FinanzasTrabajoFinal.Service;
using Microsoft.EntityFrameworkCore;

// 1. Registra esto al inicio
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

// 2. Creas el builder UNA SOLA VEZ
var builder = WebApplication.CreateBuilder(args);

// --- 3. REGISTRA TODOS TUS SERVICIOS AQUÍ ---

// Lee la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("No se encontró la cadena de conexión 'DefaultConnection'. Revisa tu appsettings.json.");

// Registra el DbContext
builder.Services.AddDbContext<FinanzasContext>(options =>
    options.UseSqlServer(connectionString));

// Registra los servicios
builder.Services.AddScoped<AuthService>();

// ¡CAMBIO IMPORTANTE! Debe ser AddScoped para que cada usuario tenga su sesión
builder.Services.AddScoped<UserStateService>();

// Registra los componentes de Blazor (Razor Components)
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