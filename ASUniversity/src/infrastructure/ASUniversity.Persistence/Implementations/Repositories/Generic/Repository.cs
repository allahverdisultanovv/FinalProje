﻿using ASUniversity.Application.Abstractions.Repositories;
using ASUniversity.Domain.Entities;
using ASUniversity.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ASUniversity.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;
        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public IQueryable<T> GetAllSelect(params string[]? includes)
        {
            IQueryable<T> query = _table;
            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
        public IQueryable<T> GetAll(
            Expression<Func<T, bool>>? whereExpression = null,
            Expression<Func<T, object>>? orderExpression = null,
            int skip = 0,
            int take = 0,
            bool isDescending = false,
            bool isTracking = false,
            bool ignoreQuery = false,
            params string[]? includes
            )
        {
            IQueryable<T> query = _table;

            if (whereExpression != null)
                query = query.Where(whereExpression);


            if (includes != null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }


            if (orderExpression != null)
                query = isDescending ? query.OrderByDescending(orderExpression) : query.OrderBy(orderExpression);


            query = query.Skip(skip);

            if (take != 0)
                query = query.Take(take);

            if (ignoreQuery)
                query.IgnoreQueryFilters();
            return isTracking ? query : query.AsNoTracking();
        }
        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = _table;

            if (includes != null)
                query = _getIncludes(query, includes);

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public void Update(T entity)
        {
            _table.Update(entity);
        }
        public async Task AddAsync(T entity)
        {
            await _table.AddAsync(entity);
        }
        public void Delete(T entity)
        {
            _table.Remove(entity);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }
        private IQueryable<T> _getIncludes(IQueryable<T> query, params string[] includes)
        {
            for (int i = 0; i < includes.Length; i++)
            {
                query = query.Include(includes[i]);
            }
            return query;
        }

    }
}
