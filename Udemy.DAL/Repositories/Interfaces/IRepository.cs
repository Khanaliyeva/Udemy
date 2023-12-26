using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Common;
using Udemy.DAL.Context;

namespace Udemy.DAL.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseAuditableEntity
    {
       Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            );

        Task<int> SaveChangesAsync();
        Task<TEntity> GetById(int Id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
