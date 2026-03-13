using Microsoft.EntityFrameworkCore;

namespace ITIApp.DAL
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IDbContextFactory<AppDbContext> _factory;

        public GenericRepository(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Set<T>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await using var context = await _factory.CreateDbContextAsync();
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var existing =  await context.Set<T>().FindAsync(id);
            if (existing == null)
                return;
            context.Entry(existing).CurrentValues.SetValues(entity); // ✅ no attach conflict
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await using var context = await _factory.CreateDbContextAsync();
            var entity = await GetByIdAsync(id);
            if (entity == null)
                return;
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
}

        //public async Task SaveChanges()
        //{
        //    await using var context = await _factory.CreateDbContextAsync();
        //    await context.SaveChangesAsync();
        //}
    }
}
