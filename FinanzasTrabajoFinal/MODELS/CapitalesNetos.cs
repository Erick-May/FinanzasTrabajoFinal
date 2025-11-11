using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanzasTrabajoFinal.MODELS
{
    [Table("Capitales_Netos")]
    public class CapitalesNetos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_CAPITAL_NETO")]
        public int IdCapitalNeto { get; set; }

        [Column("ID_ANALISIS")]
        public int IdAnalisis { get; set; }

        [Column("ANIO")]
        public int Anio { get; set; }

        [Column("CNT", TypeName = "decimal(18, 2)")]
        public decimal CNT { get; set; }

        [Column("CNO", TypeName = "decimal(18, 2)")]
        public decimal? CNO { get; set; } // El '?' permite que sea NULL

        [ForeignKey(nameof(IdAnalisis))]
        public AnalisisFinanciero AnalisisFinanciero { get; set; }
    }
}