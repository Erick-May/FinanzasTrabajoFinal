using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("USUARIOS")] 
public class Usuarios
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID_USUARIO")] // Traduce 'IdUsuario' a 'ID_USUARIO'
    public int IdUsuario { get; set; }

    [Required]
    [StringLength(100)]
    [Column("NOMBRE_USUARIO")] // Traduce 'NombreUsuario' a 'NOMBRE_USUARIO'
    public string NombreUsuario { get; set; }

    [Required]
    [StringLength(255)]
    [Column("CONTRA_HASH")] // Traduce 'ContraHash' a 'CONTRA_HASH'
    public string ContraHash { get; set; }

    [Column("FECHA_CREACION")] // Traduce 'FechaCreacion' a 'FECHA_CREACION'
    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    // Propiedad de navegación para EF Core
    public ICollection<AnalisisFinanciero> AnalisisFinancieros { get; set; }
}
