using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace BenchWeb.Repositories
{
    public abstract class CoreRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TDbContext : DbContext
    {
        private readonly TDbContext _dbContext;
        public CoreRepository(TDbContext context)
        {
            this._dbContext = context;
        }

        public async Task<List<TEntity>> GetAll()
        {
            try
            {
                return await _dbContext.Set<TEntity>().ToListAsync();
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }

        }

        public async Task<TEntity> FindById(int? id)
        {
            try
            {
                return await _dbContext.Set<TEntity>().FindAsync(id);

            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }

        }

        public async Task<TEntity> Create(TEntity entity)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {

                var entity = FindById(id);
                _dbContext.Set<TEntity>().Remove(await entity);
                await _dbContext.SaveChangesAsync();

            }
            catch (DbUpdateException e)
            {
                await Console.Out.WriteLineAsync(e.Message);
                throw;
            }
        }

       

        public Task<TEntity> FindByIdComposite(object[] keysValues)
        {
            throw new NotImplementedException();
        }
    }
}
