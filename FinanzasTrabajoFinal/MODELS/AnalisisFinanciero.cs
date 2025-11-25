using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic; // Necesario para la lista

namespace FinanzasTrabajoFinal.MODELS // <--- ESTO FALTABA
{
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

        // Propiedad de navegación (Usuario)
        [ForeignKey(nameof(IdUsuario))]
        public Usuarios Usuario { get; set; }

        // === ESTA ES LA PROPIEDAD QUE FALTABA PARA LOS GRÁFICOS ===
        // Permite acceder a la lista de cuentas del Balance General de este análisis
        public virtual ICollection<BGConcepto> BGConceptos { get; set; } = new List<BGConcepto>();
    }
}