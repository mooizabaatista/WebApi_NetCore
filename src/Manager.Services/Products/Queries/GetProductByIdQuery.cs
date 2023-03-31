using Manager.Domain.Entities;
using MediatR;
using System;

namespace Manager.Services.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Produto>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}