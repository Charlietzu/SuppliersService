using SuppliersService.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SuppliersService.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Create(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetAll();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}