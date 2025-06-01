﻿using Sigma.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sigma.Application.Dtos
{
    public class ProjetoDtoAtualizacao
    {
        public string? Nome { get; set; }
        public StatusProjeto Status { get; set; }
        public ClassificaoDeRisco Classificacao { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? PrevisaoTermino { get; set; }
        public DateTime? DataRealTermino { get; set; }
        public decimal? OrcamentoFinal { get; set; }
    }
}
