using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Izmainas.API.Domain.Abstractions
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Guid id);
        Task CreateAsync(T item);
        void Update(T item);
        Task DeleteAsync(Guid id);
        Task<bool> SaveChangesAsync();
    }
}