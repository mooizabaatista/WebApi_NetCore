
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
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, bool>
    {
        private readonly IProdutoRepository _repository;

        public ProductDeleteCommandHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var produto = await _repository.Get(request.Id);
            if (produto == null)
            {
                throw new ApplicationException(SharedConstants.FailedOnRemoveEntity);
            }
            else
            {
                var result = await _repository.Delete(produto.Id);
                return result;
            }
        }
    }
}