using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Manager.Core.Shared;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Services.Products.Queries;
using MediatR;

namespace Manager.Services.Products.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Produto>>
    {
        private readonly IProdutoRepository _repository;

        public GetProductQueryHandler(IProdutoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Produto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var produtos = await _repository.Get();

            if (produtos == null)
            {
                throw new ApplicationException(SharedConstants.FailedOnGetEntities);
            }
            else
            {
                return produtos;
            }
        }
    }
}