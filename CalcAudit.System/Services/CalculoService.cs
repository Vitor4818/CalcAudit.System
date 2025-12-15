using CalcAudit.System.Models;
using System.Web;

namespace CalcAudit.System.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public CalculoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            var baseUrl = configuration["ApiSettings:BaseUrl"];
            _apiKey = configuration["ApiSettings:ApiKey"]
                      ?? throw new Exception("ApiKey não configurada.");

            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("BaseUrl não configurada.");

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<CalculoDto?> SalvarCalculoAsync(CalculoDto calculo)
        {
            var response = await _httpClient.PostAsJsonAsync(
                $"api/calculadora?apikey={_apiKey}", calculo);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();

            if (!int.TryParse(content, out var id))
                return null;

            calculo.Id = id;
            return calculo;
        }


        public async Task<List<CalculoDto>> ObterHistoricoAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<CalculoDto>>($"api/calculadora?apikey={_apiKey}")
                   ?? new List<CalculoDto>();
        }

        public async Task DeletarCalculoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/calculadora?id={id}&apikey={_apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                var detalheErro = await response.Content.ReadAsStringAsync();
                throw new Exception($"Falha ao excluir ({response.StatusCode}): {detalheErro}");
            }
        }
    }
}