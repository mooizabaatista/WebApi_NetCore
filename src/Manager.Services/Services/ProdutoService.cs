using AutoMapper;
using Manager.Core.Shared;
using Manager.Services.Dtos;
using Manager.Services.Interfaces;
using Manager.Services.Products.Commands;
using Manager.Services.Products.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Services.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;


        public ProdutoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProdutoDto>> Get()
        {
            var productsQuery = new GetProductQuery();
            if (productsQuery == null)
                throw new Exception(SharedConstants.FailedOnGetEntities);

            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProdutoDto>>(result);
        }


        public async Task<ProdutoDto> Get(Guid id)
        {
            var productQuery = new GetProductByIdQuery(id);
            if (productQuery == null)
                throw new Exception(SharedConstants.FailedOnGetEntityById);

            var result = await _mediator.Send(productQuery);
            return _mapper.Map<ProdutoDto>(result);
        }

        public async Task<ProdutoDtoFlat> Create(ProdutoDtoFlat produtoDto)
        {
            if (produtoDto.Id == Guid.Empty)
                produtoDto.Id = Guid.NewGuid();

            var productCreateCommand = _mapper.Map<ProductCreateCommand>(produtoDto);
            await _mediator.Send(productCreateCommand);
            return produtoDto;
        }

        public async Task<ProdutoDtoFlat> Update(ProdutoDtoFlat produtoDto)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(produtoDto);
            await _mediator.Send(productUpdateCommand);
            return produtoDto;
        }

        public async Task<bool> Delete(Guid id)
        {
            var productRemoveCommand = _mapper.Map<ProductDeleteCommand>(id);
            return await _mediator.Send(productRemoveCommand);
        }
    }
}