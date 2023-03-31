using System;
using System.Threading;
using System.Threading.Tasks;
using Manager.Core.Shared;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.Products.Commands;
using MediatR;

namespace Manager.Services.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Produto>
    {
        private readonly IProdutoRepository _repository;

        public ProductUpdateCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.Get(request.Id);

            if (produto == null)
            {
                throw new ApplicationException(SharedConstants.FailedOnUpdateEntity);
            }
            else
            {
                produto.Id = request.Id;
                produto.Nome = request.Nome;
                produto.Valor = request.Valor;
                produto.CategoriaId = request.CategoriaId;

                return await _repository.Update(produto);
            }
        }
    }
}