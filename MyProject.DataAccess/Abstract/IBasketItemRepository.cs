using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Abstract
{
    public interface IBasketItemRepository: IBaseEntityRepository<BasketItem>
    {
        Task<BasketItem> GetByUserIdBasketItemAsync(Guid basketId, Guid productId);
        Task<BasketItem> AddItemBasketAsync(BasketItem basketItem);
        Task<bool> DeleteItemBasketAsync(Guid itemId, string userId);

        public Task<decimal> CalculateBasketTotalAsync(Guid basketId);
    }


}
