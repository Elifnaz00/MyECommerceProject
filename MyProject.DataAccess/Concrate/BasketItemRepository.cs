using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        public async Task<BasketItem> GetByUserIdBasketItemAsync(Guid basketId, Guid productId)
        {
            var value = await _myProjectContext.BasketItems
                .Include(x => x.Basket).Include(x => x.Product).AsNoTracking().FirstOrDefaultAsync(x => x.ProductId == productId && x.BasketId == basketId);

            return value;
        }


        public async Task<BasketItem> AddItemBasketAsync(BasketItem basketItem)
        {
            await _myProjectContext.BasketItems.AddAsync(basketItem);
            await _myProjectContext.SaveChangesAsync();

            var item = await _myProjectContext.BasketItems
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == basketItem.Id)
                ?? throw new Exception("Sepet öğesi veritabanında bulunamadı."); 

            return item;
        }


        public async Task<bool> DeleteItemBasketAsync(Guid itemId, string userId) //sileceğin ürünün id si gerçekten o kullanıcıya mı ait? kontrol et
        {
            var item= await _myProjectContext.BasketItems.Include(x=> x.Basket).FirstOrDefaultAsync(x => x.Id == itemId);
            if(item is null || item.Basket.AppUserId != userId)
                return false;

            _myProjectContext.BasketItems.Remove(item);
            await _myProjectContext.SaveChangesAsync();

            return true;
            
        }

        public async Task<decimal> CalculateBasketTotalAsync(Guid basketId)
        {
            return await _myProjectContext.BasketItems
                .Where(bi => bi.BasketId == basketId)
                .SumAsync(bi => bi.Quantity * bi.Product.Price);
        }
    }
    
}
