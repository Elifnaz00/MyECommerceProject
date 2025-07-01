using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Concrate;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Request
{
    public class GetAllProductQueryRequest : IRequest<IList<GetAllProductQueryResponse>>
    {



    }


}
