
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.DTO.Models.OrderStatusViewModel;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Abstract
{
    public interface IOrderRepository : IBaseEntityRepository<Order>
    {
        Task<List<Order>> GetOrdersByUserId(string userId);
        int GetOrderCount();
        decimal GetOrderTotalAmount();
      
    }
}
 