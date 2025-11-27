using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinanzasTrabajoFinal.Service
{
    public class GeminiService
    {
        private readonly HttpClient _httpClient;

        // Tu clave (La vi en tus capturas, está bien)
        private const string ApiKey = "AIzaSy2025";

        // === EL CAMBIO FINAL ===
        // 1. Usamos 'v1beta' (Obligatorio para modelos 1.5)
        // CAMBIO FINAL: Usamos 'gemini-2.5-flash' (El modelo activo en 2025)
        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

        public GeminiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> AnalizarDatos(string promptDelUsuario)
        {
            var url = $"{BaseUrl}?key={ApiKey}";

            var requestBody = new
            {
                contents = new[]
                {
                    new { parts = new[] { new { text = promptDelUsuario } } }
                }
            };

            var jsonContent = new StringContent(
                JsonSerializer.Serialize(requestBody),
                Encoding.UTF8,
                "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return $"Error de Google ({response.StatusCode}): {error}";
                }

                var responseString = await response.Content.ReadAsStringAsync();
                var resultado = JsonSerializer.Deserialize<GeminiResponse>(responseString);

                return resultado?.Candidates?.FirstOrDefault()?.Content?.Parts?.FirstOrDefault()?.Text
                       ?? "La IA respondió pero no trajo texto.";
            }
            catch (Exception ex)
            {
                return $"Error interno del programa: {ex.Message}";
            }
        }

        private class GeminiResponse { [JsonPropertyName("candidates")] public Candidate[]? Candidates { get; set; } }
        private class Candidate { [JsonPropertyName("content")] public Content? Content { get; set; } }
        private class Content { [JsonPropertyName("parts")] public Part[]? Parts { get; set; } }
        private class Part { [JsonPropertyName("text")] public string? Text { get; set; } }
    }
}