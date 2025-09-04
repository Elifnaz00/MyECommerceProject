using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Products.Queries.Request;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Handlers.QueryHandlers
{
    public class GetNewProductsQueryHandler : IRequestHandler<GetNewProductsQueryRequest, IList<GetNewProductsQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetNewProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetNewProductsQueryResponse>> Handle(GetNewProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var value =   _productRepository.GetNewArrivalProducts();
            var products = await value.ToListAsync();

            var result= _mapper.Map<IList<GetNewProductsQueryResponse>>(products);
            return result;

        }

        
    }
}
