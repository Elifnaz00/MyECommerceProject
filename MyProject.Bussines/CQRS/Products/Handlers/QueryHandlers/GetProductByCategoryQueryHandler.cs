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
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, IList<GetProductByCategoryQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }




        public async Task<IList<GetProductByCategoryQueryResponse>> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            var queryableProducts =  _productRepository.GetProductByCategory(request.Id);
            var products = await queryableProducts.ToListAsync();
                 
            var result = _mapper.Map<IList<GetProductByCategoryQueryResponse>>(products);
            return result;
        }


    }
}
