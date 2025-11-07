using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ORIGEN_APLICACION")]
public class OrigenAplicacion
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_OA")]
    public int IdOa { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("PERIODO_INICIAL")]
    public int PeriodoInicial { get; set; }

    [Column("PERIODO_FINAL")]
    public int PeriodoFinal { get; set; }

    [Column("CONCEPTO")]
    public string Concepto { get; set; }

    [Column("FLUJO")]
    public string Flujo { get; set; } // 'ORIGEN' o 'APLICACION'

    [Column("VALOR", TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }
}