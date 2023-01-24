using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using pocketbook.Core.IRepository;
using pocketbook.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pocketbook.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext context;
        protected DbSet<T> dbSet;

        protected readonly ILogger logger;

        public GenericRepository(ApplicationDbContext _context,
            ILogger _logger)
        {
            context = _context;
            logger = _logger;
            dbSet = context.Set<T>();

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id) ;
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
