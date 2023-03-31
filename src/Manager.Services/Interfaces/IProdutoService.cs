using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Services.Dtos;

namespace Manager.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> Get();
        Task<ProdutoDto> Get(Guid id);
        Task<ProdutoDtoFlat> Create(ProdutoDtoFlat userDto);
        Task<ProdutoDtoFlat> Update(ProdutoDtoFlat userDto);
        Task<bool> Delete(Guid id);
    }
}