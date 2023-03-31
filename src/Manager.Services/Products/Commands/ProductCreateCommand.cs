using System;

namespace Manager.Services.Products.Commands
{
    public class ProductCreateCommand : ProductCommand
    {
        public Guid Id { get; set; }
    }
}