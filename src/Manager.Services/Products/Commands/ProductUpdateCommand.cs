using System;

namespace Manager.Services.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public Guid Id { get; set; }
    }
}