using Sigma.Domain.Enums;

namespace Sigma.Domain.Dtos
{
    public class ProjetoNovoDto
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? PrevisaoTermino { get; set; }
        public StatusProjeto Status { get; set; }
        public ClassificaoDeRisco Classificacao { get; set; }
        public decimal? OrcamentoFinal { get; set; }

    }
}
