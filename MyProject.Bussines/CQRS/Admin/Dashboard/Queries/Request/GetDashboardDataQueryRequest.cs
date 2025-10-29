using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Response;

namespace MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Request
{
    public class GetDashboardDataQueryRequest: IRequest<GetDashboardDataQueryResponse>
    {
    }
}
