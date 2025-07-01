using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Request
{
    public class GetProductByCategoryQueryRequest : IRequest<IList<GetProductByCategoryQueryResponse>>
    {
        public Guid Id { get; set; }
    }



}


