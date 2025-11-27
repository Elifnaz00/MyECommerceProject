
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
            return await _context.Orders.AsNoTracking()
                .Include(o => o.OrderStatus)
                .Include(o => o.Basket)
                .ThenInclude(y => y.BasketItems)
                .ThenInclude(z => z.Product)
                .Where(o => o.AppUserId == userId)
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


        public async Task CancelOrderAsync(Order orderValue)
        {
           
            EntityEntry<Order> entityEntry = _context.Orders.Remove(orderValue);
            await _context.SaveChangesAsync();
            orderValue.OrderStatusId = Guid.Parse("88888888-8888-8888-8888-888888888888");
            _context.Orders.Update(orderValue);
            await _context.SaveChangesAsync();
           
        }


    }
}
