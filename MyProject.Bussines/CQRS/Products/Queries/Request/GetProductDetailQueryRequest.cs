using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Request
{
    public class GetProductDetailQueryRequest : IRequest<GetProductDetailQueryResponse>
    {
        public Guid Id { get; set; }
    }


}
