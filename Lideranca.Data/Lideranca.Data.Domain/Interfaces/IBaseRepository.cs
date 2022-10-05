using Lideranca.Data.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lideranca.Data.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(long id);
        Task<IEnumerable<T>> GetListAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
