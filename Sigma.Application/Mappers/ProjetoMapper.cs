using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;

namespace Sigma.Application.Mappers
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<ProjetoDto, Projeto>();
            CreateMap<Projeto, ProjetosDto>();
            CreateMap<Projeto, ProjetoDto>();
            CreateMap<ProjetoDtoAtualizacao, Projeto>();
        }
    }
}