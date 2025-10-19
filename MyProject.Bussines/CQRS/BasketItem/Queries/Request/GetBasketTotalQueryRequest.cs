using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Queries.Response;

namespace MyProject.Bussines.CQRS.BasketItem.Queries.Request
{
    public class GetBasketTotalQueryRequest: IRequest<GetBasketTotalQueryResponse>
    {
        public Guid BasketId { get; set; }
    }
}
