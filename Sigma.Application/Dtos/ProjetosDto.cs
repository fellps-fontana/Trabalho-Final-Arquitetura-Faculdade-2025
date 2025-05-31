using Sigma.Domain.Enums;

namespace Sigma.Application.Dtos
{
    public class ProjetosDto
    {
        public long Id { get; set; }
        public string? Nome { get; set; }
        public StatusProjeto Status { get; set; }
        public ClassificaoDeRisco Classificacao { get; set; }

        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? PrevisaoTermino { get; set; }
        public DateTime? DataRealTermino { get; set; }
        public decimal? OrcamentoFinal { get; set; }
    }
}
