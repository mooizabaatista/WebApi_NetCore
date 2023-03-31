using System;
using Manager.Domain.Entities;
using MediatR;

namespace Manager.Services.Products.Commands
{
    public class ProductCommand : IRequest<Produto>
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
    }
}