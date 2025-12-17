using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
        }
    }
}
