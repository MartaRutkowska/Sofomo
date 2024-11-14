using Microsoft.EntityFrameworkCore;

namespace Sofomo.CQRS.Repositories.Shared
{
    public class Repository<TEntity>(DbContext context) : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context = context;

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();
        public async Task<TEntity?> GetAsync(int id) => await Context.Set<TEntity>().FindAsync(id);
        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

    }
}
