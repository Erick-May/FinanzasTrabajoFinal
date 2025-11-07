using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("BG_CONCEPTO")]
public class BGConcepto
{
    [Key]
    [Column("ID_BG_CONCEPTO")]
    public int IdBgConcepto { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("AÑO")]
    public int Anio { get; set; }

    [Column("CONCEPTO")]
    public string Concepto { get; set; }

    [Column("TIPO")]
    public string Tipo { get; set; } // 'ACTIVO', 'PASIVO', 'CAPITAL'

    [Column("VALOR", TypeName = "decimal(18, 2)")]
    public decimal Valor { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }

    //Hola soy yo 
}