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

        
        public IQueryable<T?> GetAll() => entity.AsNoTracking();
       
        public async Task<T?> GetByIdAsync(Guid id) => await this.entity.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
       

        public async Task<T?> FindByIdAsync(Guid id) =>  await entity.FindAsync(id);
       

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate) => this.entity.AsNoTracking().Where(predicate); 
       

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


        public async Task<bool> DeleteAsync(T entity)
        {
             EntityEntry<T> entityEntry = this.entity.Remove(entity);
             await _myProjectContext.SaveChangesAsync();
             return true;

        }

        public async Task<bool> UpdateAsync(T entity)
        {
             EntityEntry<T> entityEntry = this.entity.Update(entity);
            await _myProjectContext.SaveChangesAsync();
            return true;
         
        }
     
    }
}
