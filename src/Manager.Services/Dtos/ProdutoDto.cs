using System;

namespace Manager.Services.Dtos
{
    public class ProdutoDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public virtual CategoriaDto Categoria { get; set; }

        public ProdutoDto() { }

        public ProdutoDto(Guid id, string nome, decimal valor)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
        }
    }
}