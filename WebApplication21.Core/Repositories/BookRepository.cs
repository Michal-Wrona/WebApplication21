using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication21.Core.Data;
using WebApplication21.Core.Entities;
using WebApplication21.Core.Interfaces;

namespace WebApplication21.Core.Repositories
{
    public class BookRepository<T> : IBookRepository<T> where T : BaseEntity
    {
        private readonly WebApplication21DbContext _context;
        private readonly DbSet<T> _entities;

        public BookRepository(WebApplication21DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _entities = _context.Set<T>();
        }

        public async Task<T> Get(int id)
        {
            return await _entities.SingleOrDefaultAsync(s => s.Id == id);

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public void Post(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(int id)
        {

        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}
