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

        base.OnModelCreating(modelBuilder);
    }
}