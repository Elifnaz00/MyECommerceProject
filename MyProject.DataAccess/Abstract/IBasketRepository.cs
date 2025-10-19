using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Abstract
{
    public interface IBasketRepository : IBaseEntityRepository<Basket>
    {
        public Task<Basket> GetBasketByUserAsync(string userId);
        public Task<IEnumerable<BasketItem>> GetActiveBasketItemsByUserIdAsync(string userId);

    }
       
}
