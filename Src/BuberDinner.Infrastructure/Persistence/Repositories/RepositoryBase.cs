using BuberDinner.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _dbContext;

        public RepositoryBase(ApplicationDbContext repositoryDbContext)
        {
            _dbContext = repositoryDbContext;
        }

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges
                ? _dbContext.Set<T>().AsNoTracking()
                : _dbContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
            !trackChanges
                ? _dbContext.Set<T>()
                    .Where(expression)
                    .AsNoTracking()
                : _dbContext.Set<T>()
                    .Where(expression);

        public void Create(T entity) => _dbContext.Set<T>().Add(entity);
        public void Update(T entity) => _dbContext.Set<T>().Update(entity);
        public void Delete(T entity) => _dbContext.Set<T>().Remove(entity);
    }
}
