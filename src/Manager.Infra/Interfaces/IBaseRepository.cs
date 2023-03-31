using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Manager.Domain.Entities;

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<List<T>> Get();
        Task<T> Get(Guid id);
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task<bool> Delete(Guid id);
    }
}