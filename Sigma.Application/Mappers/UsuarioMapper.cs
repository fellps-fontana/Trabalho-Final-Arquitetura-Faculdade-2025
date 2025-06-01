using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Domain.Entities;

namespace Sigma.Application.Mappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDto>();

            CreateMap<UsuarioDto, Usuario>();
        }
    }
}
