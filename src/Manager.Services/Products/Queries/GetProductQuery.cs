using System.Collections.Generic;
using Manager.Domain.Entities;
using MediatR;

namespace Manager.Services.Products.Queries
{
    public class GetProductQuery : IRequest<IEnumerable<Produto>>
    {
    }
}