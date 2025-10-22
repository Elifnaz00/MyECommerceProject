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
    public class BasketRepository : GenericRepository<Basket>, IBasketRepository
    {
        private readonly MyProjectContext _myProjectContext;

        public BasketRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _myProjectContext = myProjectContext;
        }

       
        public async Task<Basket> GetBasketByUserAsync(string userId)
        {
            var result = await _myProjectContext.Baskets.AsNoTracking()
                .Where(e => e.AppUserId == userId).FirstOrDefaultAsync(x => x.Active == true);
            return result;
        }

        public async Task <IEnumerable<BasketItem?>> GetActiveBasketItemsByUserIdAsync(string userId)
        {

            var result = await _myProjectContext.Baskets.Include(x => x.BasketItems).ThenInclude(x => x.Product).Where(e => e.AppUserId == userId).FirstOrDefaultAsync(x => x.Active);
           
            return result?.BasketItems;
        }
       
    }
}
