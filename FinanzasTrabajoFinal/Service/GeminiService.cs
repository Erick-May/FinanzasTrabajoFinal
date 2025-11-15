using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Google.GenerativeAI.Core; // <--- Namespace corregido
using Google.GenerativeAI.Models; // <--- Namespace corregido

namespace FinanzasTrabajoFinal.Service
{
    public class GeminiService
    {
        private readonly GenerativeModel _model;

        public GeminiService(IConfiguration configuration)
        {
            var apiKey = configuration["Gemini:ApiKey"] ??
                         throw new InvalidOperationException("API Key de Gemini no encontrada.");

            // La inicialización es un poco diferente para este paquete
            _model = new GenerativeModel(apiKey, ModelNames.Gemini_1_5_Flash);
        }

        public async Task<string> GenerarInterpretacion(string prompt)
        {
            try
            {
                // Este método de llamada es el correcto para este paquete
                var response = await _model.GenerateContentAsync(prompt);

                if (!string.IsNullOrEmpty(response.Text))
                {
                    return response.Text;
                }
                else
                {
                    return "La IA no devolvió una respuesta de texto.";
                }
            }
            catch (Exception ex)
            {
                return $"Error al contactar la IA: {ex.Message}";
            }
        }
    }
}