using FinanzasTrabajoFinal.MODELS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace FinanzasTrabajoFinal.Data
{
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
        public DbSet<CapitalesNetos> CapitalesNetos { get; set; }
        public DbSet<FlujoEfectivo> FlujosEfectivo { get; set; }
        public DbSet<DuPont> DuPonts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración opcional para validaciones
            modelBuilder.Entity<OrigenAplicacion>()
                .Property(oa => oa.Flujo)
                .HasMaxLength(10);

            base.OnModelCreating(modelBuilder);
        }
    }
}