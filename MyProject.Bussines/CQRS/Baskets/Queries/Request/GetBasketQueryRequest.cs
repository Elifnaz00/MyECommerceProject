using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Baskets.Queries.Response;

namespace MyProject.Bussines.CQRS.Baskets.Queries.Request
{
    public class GetBasketQueryRequest: IRequest<GetBasketQueryResponse>
    {
        public string UserId { get; set; }
    }
}
