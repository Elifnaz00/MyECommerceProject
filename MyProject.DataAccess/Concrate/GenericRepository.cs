using Castle.Core.Logging;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;

using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class GenericRepository<T> : IBaseEntityRepository<T> where T :  BaseEntity
    {
        private readonly MyProjectContext _myProjectContext;
        //private readonly ILogger _logger;

        public GenericRepository(MyProjectContext myProjectContext)
        {
            _myProjectContext = myProjectContext;
           
        }

        protected DbSet<T> entity => _myProjectContext.Set<T>();

        
        public async Task<IQueryable<T?>> GetAllAsync()
        {
            return entity.AsNoTracking();
        }



        public async Task<T?> GetByIdAsync(Guid id)
        {
            var result=  await this.entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
            return result;
        }



        public async Task<T?> FindByIdAsync(Guid id)
        {

            return await entity.FindAsync(id);

        }



        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return this.entity.AsNoTracking().Where(predicate); ;
        }



        public async Task<T> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await this.entity.AddAsync(entity);
           
            await _myProjectContext.SaveChangesAsync();
            return entity;
          
        }



        public async Task AddRangeAsync(List<T> entities)
        {
            await this.entity.AddRangeAsync(entities);
            await _myProjectContext.SaveChangesAsync();


        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            try
            {
                var value= await this.entity.FirstOrDefaultAsync(x => x.Id == id);
                if (value is null) return false;
               
                EntityEntry<T> entityEntry = this.entity.Remove(value);
                await _myProjectContext.SaveChangesAsync();
                return entityEntry.State== EntityState.Deleted;
                  
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool Update(T entity)
        {
            try
            {
                EntityEntry<T> entityEntry = this.entity.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
     
    }
}
