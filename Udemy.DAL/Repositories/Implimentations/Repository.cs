using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Common;
using Udemy.DAL.Context;
using Udemy.DAL.Repositories.Interfaces;

namespace Udemy.DAL.Repositories.Implimentations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await Table.AddAsync(entity);
            return entity;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();


        public async Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null,
            Expression<Func<TEntity, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            )
        {
            IQueryable<TEntity> query = Table;
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if (expressionOrder is not null)
            {
                query = isDescending ? query.OrderByDescending(expressionOrder) : query.OrderBy(expressionOrder);
            }
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query.Include(includes[i]);
                }
            }

            return query.Where(x => !x.IsDeleted);
        }

        public async Task<int> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        }


        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Table.Update(entity);

            return entity;
        }


        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            entity.IsDeleted = true;

            Table.Update(entity);

            return entity;
        }
    }
}
