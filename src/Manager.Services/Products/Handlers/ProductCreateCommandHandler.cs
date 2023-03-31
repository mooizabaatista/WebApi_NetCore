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
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Produto>
    {
        private readonly IProdutoRepository _repository;

        public ProductCreateCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Id, request.Nome, request.Valor, request.CategoriaId);
            if (produto == null)
            {
                throw new ApplicationException(SharedConstants.FailedOnSaveEntity);
            }
            else
            {
                var product = await _repository.Create(produto);
                return product;
            }
        }
    }
}
