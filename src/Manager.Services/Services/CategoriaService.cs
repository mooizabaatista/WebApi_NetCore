using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.Dtos;
using Manager.Services.Interfaces;

namespace Manager.Services.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CategoriaDto>> Get()
        {
            var cateogorias = await _repository.Get();
            var cateogoriasDto = _mapper.Map<List<CategoriaDto>>(cateogorias);
            return cateogoriasDto;
        }

        public async Task<CategoriaDto> Get(Guid id)
        {
            var categoria = await _repository.Get(id);
            var categoriaDto = _mapper.Map<CategoriaDto>(categoria);
            return categoriaDto;
        }

        public async Task<CategoriaDtoFlat> Create(CategoriaDtoFlat categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            var categoriaAdd = await _repository.Create(categoria);
            return _mapper.Map<CategoriaDtoFlat>(categoriaAdd);
        }

        public async Task<CategoriaDtoFlat> Update(CategoriaDtoFlat categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            var categoriaUpdated = await _repository.Update(categoria);
            return _mapper.Map<CategoriaDtoFlat>(categoriaUpdated);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}