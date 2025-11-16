using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FinanzasTrabajoFinal.MODELS
{
    [Table("FLUJO_EFECTIVO")]
    public class FlujoEfectivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID_FLUJO")]
        public int IdFlujo { get; set; }

        [Column("ID_ANALISIS")]
        public int IdAnalisis { get; set; }

        [Column("CONCEPTO")]
        public string Concepto { get; set; }

        [Column("TIPO_FLUJO")]
        public string TipoFlujo { get; set; } // 'Operación', 'Inversión', 'Financiación', 'Resumen'

        [Column("ORDEN")]
        public int Orden { get; set; }

        [Column("VALOR", TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        [ForeignKey(nameof(IdAnalisis))]
        public AnalisisFinanciero AnalisisFinanciero { get; set; }
    }
}
