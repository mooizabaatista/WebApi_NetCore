using System.Collections.Generic;

namespace Manager.Domain.Entities
{
    public class Categoria : BaseEntity
    {
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}