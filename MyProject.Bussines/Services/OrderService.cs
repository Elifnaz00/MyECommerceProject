using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Services
{
   
    public class OrderService : IOrderService
    {
        private readonly  IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CancelOrderServiceAsync(Guid orderId) 
        {
           var hasCancelOrder= await _orderRepository.FindByIdAsync(orderId);
           if (hasCancelOrder is null) 
               throw new NotFoundException("Silinmek istenen sipariş bulunamadı.");
           
            hasCancelOrder.IsDeleted = true;
            hasCancelOrder.OrderStatusId = Guid.Parse("88888888-8888-8888-8888-888888888888");
            await _orderRepository.UpdateAsync(hasCancelOrder);
          
             

        }
    }
}
