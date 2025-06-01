using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sigma.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public async Task<bool> Inserir(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            var sucesso = await _usuarioRepository.Inserir(usuario);
            return sucesso;
        }


        public async Task<bool> Atualizar(int id, UsuarioDto usuarioDto)
        {
            var usuarioExistente = await _usuarioRepository.BuscarPeloId(id);
            if (usuarioExistente == null) return false;

            _mapper.Map(usuarioDto, usuarioExistente);

            return await _usuarioRepository.Atualizar(usuarioExistente);
        }

        public async Task<List<UsuarioDto>> BuscarTodos()
        {
            var usuarios = await _usuarioRepository.BuscarTodos();
            return _mapper.Map<List<UsuarioDto>>(usuarios);
        }

        public async Task<UsuarioDto> BuscarPeloId(int id)
        {
            var usuario = await _usuarioRepository.BuscarPeloId(id);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<bool> Deletar(int id)
        {
            var usuario = await _usuarioRepository.BuscarPeloId(id);
            if (usuario == null) return false;

            return await _usuarioRepository.Deletar(usuario);
        }
        public async Task<UsuarioDto> BuscarPeloNome(string nome)
        {
            var usuario = await _usuarioRepository.BuscarPeloUsername(nome);
            return usuario == null ? null : _mapper.Map<UsuarioDto>(usuario);
        }
    }
}
