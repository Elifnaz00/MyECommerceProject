using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public interface IBasketService
    {
        public Task<Basket> GetBasketByUserServiceAsync(string userId);

        public Task<Basket> AddBasketAsync(Basket basket);  
        public Task<IEnumerable<BasketItem>> GetActiveBasketItemsByUserIdServiceAsync(string userId);

    }
}
