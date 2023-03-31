using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly ManagerContext _context;

        public ProdutoRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Produto>> Get()
        {
            var produtos = await _context.Produtos
                .Include(x => x.Categoria)
                .ToListAsync();

            return produtos;
        }

        public override async Task<Produto> Get(Guid id)
        {
            var produto = await _context.Produtos
                .Include(x => x.Categoria)
                .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return produto;
        }

    }
}