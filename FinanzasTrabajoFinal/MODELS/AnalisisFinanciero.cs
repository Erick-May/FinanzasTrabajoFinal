using FinanzasTrabajoFinal.MODELS; // Asumo que Usuarios está en este namespace
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("ANALISIS_FINANCIERO")]
public class AnalisisFinanciero
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_ANALISIS")]
    public int IdAnalisis { get; set; }

    [Column("ID_USUARIO")]
    public int IdUsuario { get; set; }

    [Column("FECHA_ANALISIS")]
    public DateTime FechaAnalisis { get; set; } = DateTime.Now;

    [Column("NOMBRE_ARCHIVO")]
    public string NombreArchivo { get; set; }

    // Propiedad de navegación (Foreign Key)
    [ForeignKey(nameof(IdUsuario))]
    public Usuarios Usuario { get; set; }
}