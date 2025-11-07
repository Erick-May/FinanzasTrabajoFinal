using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ER_CONCEPTO")]
public class ERConcepto
{
    [Key]
    [Column("ID_ER_CONCEPTO")]
    public int IdErConcepto { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("AÑO")]
    public int Anio { get; set; }

    [Column("CONCEPTO")]
    public string Concepto { get; set; }

    [Column("VALOR", TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }
}