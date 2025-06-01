using AutoMapper;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;

namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
        }

        public async Task<bool> Inserir(ProjetoDto model)
        {
            return await _projetoRepository.Inserir(_mapper.Map<Projeto>(model));
        }
        public async Task<List<ProjetoDto>> BuscarTodos()
        {
            var projetos = await _projetoRepository.BuscarTodos();
            var projetosDto = _mapper.Map<List<ProjetoDto>>(projetos);

            foreach (var projeto in projetosDto)
            {
                projeto.DataInicio = projeto.DataInicio.ToLocalTime();

                if (projeto.PrevisaoTermino.HasValue)
                    projeto.PrevisaoTermino = projeto.PrevisaoTermino.Value.ToLocalTime();

                if (projeto.DataRealTermino.HasValue)
                    projeto.DataRealTermino = projeto.DataRealTermino.Value.ToLocalTime();
            }
            return projetosDto;

        }
        public async Task<ProjetoDto?> BuscarPeloId (int id)
        {
            var projeto = await _projetoRepository.BuscarPeloId(id);
            if (projeto == null) return null;

            var projetoDto = _mapper.Map<ProjetoDto>(projeto);

            projetoDto.DataInicio = projetoDto.DataInicio.ToLocalTime();

            if (projetoDto.PrevisaoTermino.HasValue)
                projetoDto.PrevisaoTermino = projetoDto.PrevisaoTermino.Value.ToLocalTime();

            if (projetoDto.DataRealTermino.HasValue)
                projetoDto.DataRealTermino = projetoDto.DataRealTermino.Value.ToLocalTime();

            return projetoDto;
        }
        public async Task<List<ProjetoDto>> BuscarPeloStatus(StatusProjeto status)
        {
            var projetosFiltrados = await _projetoRepository.BuscarPeloStatus(status);
            var projetosDto =_mapper.Map<List<ProjetoDto>>(projetosFiltrados);
            foreach (var projeto in projetosDto)
            {
                projeto.DataInicio = projeto.DataInicio.ToLocalTime();

                if (projeto.PrevisaoTermino.HasValue)
                    projeto.PrevisaoTermino = projeto.PrevisaoTermino.Value.ToLocalTime();

                if (projeto.DataRealTermino.HasValue)
                    projeto.DataRealTermino = projeto.DataRealTermino.Value.ToLocalTime();
            }
            return projetosDto;
        }

        public async Task<bool> Atualizar(int id, ProjetoDtoAtualizacao model)
        {
            var projetoAlterar = await _projetoRepository.BuscarPeloId(id);
            if (projetoAlterar == null)
                return false;

            _mapper.Map(model, projetoAlterar);

            if (projetoAlterar.Status == StatusProjeto.Encerrado && !projetoAlterar.DataRealTermino.HasValue)
            {
                projetoAlterar.DataRealTermino = DateTime.UtcNow;
            }
            else if (projetoAlterar.Status != StatusProjeto.Encerrado && projetoAlterar.DataRealTermino.HasValue)
            {
                projetoAlterar.DataRealTermino = null;
            }

            return await _projetoRepository.Atualizar(projetoAlterar);
        }

        public async Task<bool> Deletar(int id)
        {
            var projeto = await _projetoRepository.BuscarPeloId(id);
            if (projeto == null)
                return false;

            if (projeto.Status == StatusProjeto.Iniciado ||
                projeto.Status == StatusProjeto.Planejado ||
                projeto.Status == StatusProjeto.EmAndamento ||
                projeto.Status == StatusProjeto.Encerrado)
            {
                return false;
            }

            return await _projetoRepository.Deletar(projeto);
        }
    }
}
