using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RESULTADO_VERTICAL")]
public class ResultadoVertical
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_VERTICAL")]
    public int IdVertical { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("TIPO_ESTADO")]
    public string TipoEstado { get; set; } // 'BG' o 'ER'

    [Column("AÑO")]
    public int Anio { get; set; }

    [Column("CONCEPTO")]
    public string Concepto { get; set; }

    [Column("PORCENTAJE", TypeName = "decimal(18, 4)")]
    public decimal Porcentaje { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }
}