using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;

namespace MyProject.DataAccess.Concrate
{
    public class BasketItemRepository: GenericRepository<BasketItem>, IBasketItemRepository
    {
        private readonly MyProjectContext _myProjectContext;
        public BasketItemRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _myProjectContext = myProjectContext;
        }

        public async Task<BasketItem> AddItemBasketAsync(BasketItem basketItem)
        {
            await _myProjectContext.BasketItems.AddAsync(basketItem);
            await _myProjectContext.SaveChangesAsync();
            return basketItem;
        }

        public async Task<BasketItem> GetByUserIdBasketItemAsync(Guid basketId, Guid productId)
        {   
            var value = await _myProjectContext.BasketItems
                .Include(x => x.Basket).Include(x => x.Product).AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId && x.BasketId == basketId);

            return value;
        }

      
    }
    
}
