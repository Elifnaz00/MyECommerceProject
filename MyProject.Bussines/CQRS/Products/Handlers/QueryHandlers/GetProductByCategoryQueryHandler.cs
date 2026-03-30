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
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.DTO.DTOs.CategoryDTOs;

namespace MyProject.Bussines.CQRS.Products.Handlers.QueryHandlers
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, GetProductByCategoryQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetProductByCategoryQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetProductByCategoryQueryResponse> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            var queryableProducts =  _productRepository.GetProductByCategory(request.Id);
            var products = await queryableProducts.ToListAsync();

            var categories= await _categoryRepository.GetCategoryTypesListAsync();

            return new()
            {
                Products = _mapper.Map<List<ProductDto>>(products),
                Categories = _mapper.Map<List<CategoryTypesDto>>(categories)
            };
           
        }


    }
}
