using ContosoUniversity.Data;
using SeedWork;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : Entity
    {
        // ----------------------------------------------------------
        protected LibraryContext Context { get; }

        public EntityFrameworkRepository(LibraryContext context)
        {
            Context = context;
        }

        // ----------------------------------------------------------
        public async Task<T?> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }
        public async Task<T?> GetSingle(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> List(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task Delete(T entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<T> Insert(T entity)
        {
            Context.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(T entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        // ----------------------------------------------------------
        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(Context.Set<T>().AsQueryable(), specification);
        }

    }
}
