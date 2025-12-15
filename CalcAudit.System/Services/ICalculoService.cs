using CalcAudit.System.Models;

namespace CalcAudit.System.Services
{
    public interface ICalculoService
    {
        Task<CalculoDto?> SalvarCalculoAsync(CalculoDto calculo);
        Task<List<CalculoDto>> ObterHistoricoAsync();
        Task DeletarCalculoAsync(int id);
    }
}