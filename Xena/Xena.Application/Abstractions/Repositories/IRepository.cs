using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xena.Application.Common.Models;

namespace Xena.Application.Abstractions.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(object id);
        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<IEnumerable<TEntity>> GetListAsync(bool includeAll = false);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeAll = false);
        Task<BaseResult<TEntity>> GetPagingListAsync(int page, int perPage, bool includeAll = false);
        Task<BaseResult<TEntity>> GetPagingListAsync(BaseRequest filters, bool includeAll = false);
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        void Remove(TEntity entity);
    }
}