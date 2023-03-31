using System;

namespace Manager.Services.Dtos
{
    public class ProdutoDtoFlat
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }

        public ProdutoDtoFlat() { }

        public ProdutoDtoFlat(Guid id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }
}