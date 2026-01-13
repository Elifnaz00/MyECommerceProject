using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Products.Queries.Request;
using MyProject.Bussines.CQRS.Products.Queries.Response;

using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Handlers.QueryHandlers
{
    public class GetFilteredProductQueryHandler : IRequestHandler<GetFilteredProductQueryRequest, IList<GetFilteredProductQueryResponse>>
    {

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetFilteredProductQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
          
            _mapper = mapper;
        }

        public async Task<IList<GetFilteredProductQueryResponse>> Handle(GetFilteredProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            var filteredProductValues= await _productRepository.GetFilteredProduct(request.Filter).ToListAsync();
            var filteredProductResponse = _mapper.Map<IList<GetFilteredProductQueryResponse>>(filteredProductValues);
            return filteredProductResponse;
        }
    }
}
