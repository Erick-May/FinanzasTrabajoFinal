using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RESULTADO_HORIZONTAL")]
public class ResultadoHorizontal
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_HORIZONTAL")]
    public int IdHorizontal { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("TIPO_ESTADO")]
    public string TipoEstado { get; set; } // 'BG' o 'ER'

    [Column("PERIODO_INICIAL")]
    public int PeriodoInicial { get; set; }

    [Column("PERIODO_FINAL")]
    public int PeriodoFinal { get; set; }

    [Column("CONCEPTO")]
    public string Concepto { get; set; }

    [Column("VARIACION_ABSOLUTA", TypeName = "decimal(18, 2)")]
    public decimal VariacionAbsoluta { get; set; }

    [Column("VARIACION_RELATIVA", TypeName = "decimal(18, 4)")]
    public decimal VariacionRelativa { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }
}