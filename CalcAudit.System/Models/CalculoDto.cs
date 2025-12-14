using System.ComponentModel.DataAnnotations;

namespace CalcAudit.System.Models
{
    /// <summary>
    /// Objeto de transferência de dados que representa um cálculo matemático na API.
    /// </summary>
    public class CalculoDto
    {
        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "O Valor A é obrigatório.")]
        public decimal? ValorA { get; set; }

        [Required(ErrorMessage = "O Valor B é obrigatório.")]
        public decimal? ValorB { get; set; }

        public decimal Resultado { get; set; }

        [Required]
        public string Operacao { get; set; } = string.Empty;

        public DateTime DataCalculo { get; set; }
    }
}