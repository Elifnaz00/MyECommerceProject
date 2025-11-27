using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Services
{
    public interface IOrderService
    {
        Task CancelOrderServiceAsync(Guid orderId);
    }
}
