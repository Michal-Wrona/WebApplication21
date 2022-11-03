using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication21.Core.Entities;

namespace WebApplication21.Core.Interfaces
{
    public interface IEntityRepository<T> where T : BaseEntity
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        void Post(T entity);
        void Delete(int id);
        Task UpdateAsync(T entity);
        Task<bool> SaveChangesAsync();
    }
}
