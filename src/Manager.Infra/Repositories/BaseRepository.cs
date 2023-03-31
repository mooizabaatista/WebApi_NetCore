using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Core.Shared;
using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ManagerContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(ManagerContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public virtual async Task<List<T>> Get()
        {
            try
            {
                return await _dataset
                .AsNoTracking()
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(SharedConstants.FailedOnGetEntities + ex.Message);
            }
        }

        public virtual async Task<T> Get(Guid id)
        {
            try
            {
                return await _dataset
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id));
            }
            catch (Exception ex)
            {
                throw new Exception(SharedConstants.FailedOnGetEntityById + ex.Message);
            }
        }

        public virtual async Task<T> Create(T obj)
        {
            try
            {
                _dataset.Add(obj);
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(SharedConstants.FailedOnSaveEntity + ex.Message);
            }
        }

        public virtual async Task<T> Update(T obj)
        {
            if (obj == null)
                throw new Exception(SharedConstants.FailedOnUpdateEntity);

            try
            {
                _context.Entry(obj).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception(SharedConstants.FailedOnUpdateEntity + ex.Message);
            }
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var tEntity = await Get(id);
            if (tEntity == null)
                return false;

            try
            {
                _dataset.Remove(tEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception(SharedConstants.FailedOnRemoveEntity + ex.Message);
            }
        }
    }
}