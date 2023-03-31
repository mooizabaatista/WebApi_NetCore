using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        private readonly ManagerContext _context;

        public CategoriaRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<List<Categoria>> Get()
        {
            var categorias = await _context.Categorias
            .AsNoTracking()
            .Include(x => x.Produtos)
            .AsNoTracking()
            .ToListAsync();

            return categorias;
        }

        public override async Task<Categoria> Get(Guid id)
        {
            var produto = await _context.Categorias
            .AsNoTracking()
            .Include(x => x.Produtos)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id.Equals(id));

            return produto;
        }
    }
}