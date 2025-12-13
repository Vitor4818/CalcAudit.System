using CalcAudit.System.Models;

namespace CalcAudit.System.Services
{
    public class CalculoService : ICalculoService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        // Injetamos IConfiguration para ler o appsettings.json
        public CalculoService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;

            // Busca a URL e a Chave do arquivo de configuração
            var baseUrl = configuration["ApiSettings:BaseUrl"];
            _apiKey = configuration["ApiSettings:ApiKey"]
                      ?? throw new Exception("ApiKey não configurada no appsettings.json");

            if (string.IsNullOrEmpty(baseUrl))
                throw new Exception("BaseUrl não configurada no appsettings.json");

            _httpClient.BaseAddress = new Uri(baseUrl);
        }

        public async Task<string> SalvarCalculoAsync(CalculoDto calculo)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiKey);

            var response = await _httpClient.PostAsJsonAsync("Calculo", calculo);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            // Tratamento de erro melhorado
            var erro = await response.Content.ReadAsStringAsync();
            throw new Exception($"Erro API ({response.StatusCode}): {erro}");
        }

        public async Task<List<CalculoDto>> ObterHistoricoAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiKey);

            return await _httpClient.GetFromJsonAsync<List<CalculoDto>>("Calculo")
                   ?? new List<CalculoDto>();
        }

        public async Task DeletarCalculoAsync(int id)
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _apiKey);

            var response = await _httpClient.DeleteAsync($"Calculo/{id}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao excluir o registro na API.");
            }
        }
    }
}