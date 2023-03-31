using System;

namespace Manager.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public Produto()
        {

        }

        public Produto(Guid id, string nome, decimal valor, Guid categoriaId)
        {
            Id = id;
            Nome = nome;
            Valor = valor;
            CategoriaId = categoriaId;
        }

        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Guid CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}