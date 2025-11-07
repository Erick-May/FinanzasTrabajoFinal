using FinanzasTrabajoFinal.MODELS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class FinanzasContext : DbContext
{
    // Constructor
    public FinanzasContext(DbContextOptions<FinanzasContext> options)
        : base(options)
    {
    }

    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<AnalisisFinanciero> AnalisisFinancieros { get; set; }
    public DbSet<BGConcepto> BGConceptos { get; set; }
    public DbSet<ERConcepto> ERConceptos { get; set; }
    public DbSet<ResultadoVertical> ResultadoVerticales { get; set; }
    public DbSet<ResultadoHorizontal> ResultadoHorizontales { get; set; }
    public DbSet<RazonFinanciera> RazonesFinancieras { get; set; }
    public DbSet<OrigenAplicacion> OrigenAplicaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // Si quieres replicar la restricción CHECK de SQL, hazlo así (opcional):
        modelBuilder.Entity<OrigenAplicacion>()
            .Property(oa => oa.Flujo)
            .HasMaxLength(10); // Asume un string de max 10 caracteres

        // Corrección del error 1 (Usuario a Usuarios)
        modelBuilder.Entity<AnalisisFinanciero>()
            .HasOne<Usuarios>() // <-- CORRECCIÓN: Usa 'Usuarios' (el nombre de tu clase)
            .WithMany(u => u.AnalisisFinancieros)
            .HasForeignKey(a => a.IdUsuario);

        // Configuración para BG_CONCEPTO
        modelBuilder.Entity<BGConcepto>()
            .Property(b => b.Valor) // El nombre de la propiedad en C# es 'Valor', no 'VALOR'
            .HasColumnType("decimal(18, 2)");

        base.OnModelCreating(modelBuilder);
    }
}
