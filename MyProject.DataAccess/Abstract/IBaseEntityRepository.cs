
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Abstract
{
    public interface IBaseEntityRepository<T> where T: BaseEntity
    {

        IQueryable<T?> GetAll();
        IQueryable<T?> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T?> FindByIdAsync(Guid id);

        Task<T?> GetByIdAsync(Guid id);
       
        Task<T> AddAsync(T entity);  
        Task AddRangeAsync(List<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);



    }
}
