
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.DTO.Models.OrderStatusViewModel;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly MyProjectContext _context;
        public OrderRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _context = myProjectContext;     
        }
        
       
        public async Task<List<Order>> GetOrdersByUserId(string userId)
        {
            return await _context.Orders
                .Include(o => o.Basket)
                .ThenInclude(y => y.BasketItems)
                .ThenInclude(z => z.Product)
                .Where(o => o.AppUserId == userId && o.IsDeleted == false)
                .OrderByDescending(o => o.CreateDate)
                .ToListAsync();
        }

        public int GetOrderCount() {
            return _context.Orders.AsNoTracking().Count();

        }

        public decimal GetOrderTotalAmount()
        {
            return _context.Orders.AsNoTracking().Sum(o => o.TotalAmount);
        }

    }
}
