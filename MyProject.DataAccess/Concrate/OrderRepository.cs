
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.DTO.DTOs.OrderDTOs;
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
                .Include(o => o.OrderStatus)
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

        public async Task<List<Order>> GetActiveOrderListAsync()
        {
            /*
            var value = await _context.Orders.Include(b => b.OrderStatus).Select(a => new OrderListDto()
            {
                Id = a.Id,
                TotalAmount = a.TotalAmount,
                CreateDate = a.CreateDate,
                StatusName = a.OrderStatus.Name,
                IsDeleted = a.IsDeleted
            }).Where(a=>a.IsDeleted== false).ToListAsync();

            */

            return await _context.Orders
                .Select(u => new Order() { AppUser = u.AppUser, Id = u.Id, IsDeleted = u.IsDeleted, OrderStatus = u.OrderStatus, CreateDate= u.CreateDate , TotalAmount= u.TotalAmount})
                .AsNoTracking().Where(a => a.IsDeleted == false).ToListAsync();

        }

        public async Task<List<Order>> GetCanceledOrderListAsync()
        { 
            return await _context.Orders.Where(a => a.IsDeleted == true)
                .Select(u => new Order() {AppUser= u.AppUser, Id = u.Id, IsDeleted = u.IsDeleted, OrderStatus = u.OrderStatus, CreateDate = u.CreateDate, TotalAmount = u.TotalAmount })
                .AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetUserOrderDetailAsync(Guid id, string userId)
        {
            
            return await _context.Orders.Where(m => m.AppUserId == userId && m.Id == id).Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .Include(o => o.AppUser)
                .SingleOrDefaultAsync();
        }

        public async Task<Order> GetOrderDetailAsync(Guid id)
        {
            return await _context.Orders.Include(o => o.Basket)
                .ThenInclude(b => b.BasketItems)
                .ThenInclude(bi => bi.Product)
                .Include(o => o.AppUser)
                .SingleOrDefaultAsync(t => t.Id == id);   
        }

    }
}
