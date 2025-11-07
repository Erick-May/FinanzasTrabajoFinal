using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("RAZON_FINANCIERA")]
public class RazonFinanciera
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_RAZON")]
    public int IdRazon { get; set; }

    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("AÑO")]
    public int Anio { get; set; }

    [Column("GRUPO")]
    public string Grupo { get; set; } // 'Liquidez', 'Rentabilidad', etc.

    [Column("NOMBRE_RAZON")]
    public string NombreRazon { get; set; }

    [Column("VALOR_RAZON", TypeName = "decimal(18, 6)")]
    public decimal ValorRazon { get; set; }

    [ForeignKey(nameof(IdAnalisis))]
    public AnalisisFinanciero AnalisisFinanciero { get; set; }
}