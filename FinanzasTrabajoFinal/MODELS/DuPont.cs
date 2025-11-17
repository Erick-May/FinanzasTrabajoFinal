using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanzasTrabajoFinal.MODELS
{
    [Table("DUPONT")]
    public class DuPont
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_DUPONT")]
        public int IdDuPont { get; set; }

        [Column("ID_ANALISIS")]
        public int IdAnalisis { get; set; }

        [Column("ANIO")]
        public int Anio { get; set; }

        [Column("MARGEN_UTILIDAD", TypeName = "decimal(18, 6)")]
        public decimal MargenUtilidad { get; set; }

        [Column("ROTACION_ACTIVO", TypeName = "decimal(18, 6)")]
        public decimal RotacionActivo { get; set; }

        [Column("APALANCAMIENTO", TypeName = "decimal(18, 6)")]
        public decimal Apalancamiento { get; set; }

        [Column("ROA", TypeName = "decimal(18, 6)")]
        public decimal ROA { get; set; }

        [Column("ROE", TypeName = "decimal(18, 6)")]
        public decimal ROE { get; set; }

        [ForeignKey(nameof(IdAnalisis))]
        public AnalisisFinanciero AnalisisFinanciero { get; set; }
    }
}

