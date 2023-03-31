using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Services.Dtos;

namespace Manager.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDto>> Get();
        Task<CategoriaDto> Get(Guid id);
        Task<CategoriaDtoFlat> Create(CategoriaDtoFlat categoriaDto);
        Task<CategoriaDtoFlat> Update(CategoriaDtoFlat categoriaDto);
        Task<bool> Delete(Guid id);
    }
}