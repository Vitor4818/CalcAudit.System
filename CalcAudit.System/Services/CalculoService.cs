using CalcAudit.System.Models;
using System.Web; // Útil para garantir segurança na URL, mas vamos simples aqui

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

        public async Task<string> SalvarCalculoAsync(CalculoDto calculo)
        {
            // REMOVEMOS A LINHA DE HEADER
            // _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiKey); <--- NÃO USE MAIS

            // ADICIONAMOS A APIKEY NA URL
            var response = await _httpClient.PostAsJsonAsync($"api/calculadora?apikey={_apiKey}", calculo);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            var erro = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro API ({response.StatusCode}): {erro}");
        }

        public async Task<List<CalculoDto>> ObterHistoricoAsync()
        {
            // GET também precisa da chave na URL
            return await _httpClient.GetFromJsonAsync<List<CalculoDto>>($"api/calculadora?apikey={_apiKey}")
                   ?? new List<CalculoDto>();
        }

        public async Task DeletarCalculoAsync(int id)
        {
            // MUDANÇA: Passamos o ID como parâmetro (?id=...) e concatenamos a apikey com &
            var response = await _httpClient.DeleteAsync($"api/calculadora?id={id}&apikey={_apiKey}");

            if (!response.IsSuccessStatusCode)
            {
                var detalheErro = await response.Content.ReadAsStringAsync();
                throw new Exception($"Falha ao excluir ({response.StatusCode}): {detalheErro}");
            }
        }
    }
}