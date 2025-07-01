using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Abstract
{
    public interface IBaseEntityRepository<T> where T: BaseEntity
    {

       
        Task<IQueryable<T?>> GetAllAsync();

        IQueryable<T?> GetWhere(Expression<Func<T, bool>> predicate);
        Task<T?> FindByIdAsync(Guid id);

        Task<T?> GetByIdAsync(Guid id);
       
        Task<bool> AddAsync(T entity);  
        void AddRangeAsync(List<T> entities);
        bool Update(T entity);

        bool Delete(Guid id);



    }
}
