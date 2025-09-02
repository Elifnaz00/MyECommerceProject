using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Abouts.Queries.Response;
using MyProject.Bussines.CQRS.Orders.Queries.Response;

namespace MyProject.Bussines.CQRS.Orders.Queries.Request
{
    public class GetUserOrderQueryRequest : IRequest<GetUserOrderQueryResponse>
    {

    }
}
