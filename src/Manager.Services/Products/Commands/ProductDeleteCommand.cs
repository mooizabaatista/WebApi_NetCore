using System;
using Manager.Domain.Entities;
using MediatR;

namespace Manager.Services.Products.Commands
{
    public class ProductDeleteCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public ProductDeleteCommand(Guid id)
        {
            Id = id;
        }
    }
}