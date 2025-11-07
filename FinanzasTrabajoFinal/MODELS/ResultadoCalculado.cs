using System.Collections.Generic;

// Asegúrate de que el namespace sea el mismo de tus otros modelos
namespace FinanzasTrabajoFinal.MODELS
{
    // Esta es la clase que sacamos de Resultados.razor
    public class ResultadoCalculado
    {
        public string Concepto { get; set; } = "";
        public Dictionary<int, decimal> ValoresPorAnio { get; set; } = new();
    }
}