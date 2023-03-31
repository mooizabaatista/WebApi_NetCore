using System;
using System.Threading;
using System.Threading.Tasks;
using Manager.Core.Shared;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.Products.Queries;
using MediatR;

namespace Manager.Services.Products.Handlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Produto>
    {
        private readonly IProdutoRepository _repository;

        public GetProductByIdQueryHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<Produto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var produto = await _repository.Get(request.Id);

            if (produto == null)
            {
                throw new ApplicationException(SharedConstants.FailedOnGetEntityById);
            }
            else
            {
                return produto;
            }
        }
    }
}