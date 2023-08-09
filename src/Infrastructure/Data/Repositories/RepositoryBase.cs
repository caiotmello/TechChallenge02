using Domain.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata;

namespace Infrastructure.Data.Repositories
{
    public class RepositoryBase<T> :IRepositoryBase<T> where T : class
    {
        private readonly AppDbContext _context;
        public RepositoryBase(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _context.AddAsync(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.AddRangeAsync(entities);
                _context.SaveChanges();
                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
           
        }

        public async Task<T> GetAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public Task RemoveAsync(T entity)
        {
            try
            {
                _context.Set<T>().RemoveRange(entity);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().SingleOrDefaultAsync(predicate);
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        public Task UpdateAsync(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
                return Task.CompletedTask;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
