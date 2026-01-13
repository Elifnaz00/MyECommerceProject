using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Products.Queries.Request;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.CategoryDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Handlers.QueryHandlers
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productList = _productRepository.GetAll();
            var categoryList = await _categoryRepository.GetCategoryTypesListAsync();
            return new GetAllProductQueryResponse
            {
                Products = _mapper.Map<List<ProductDto>>(productList),
                Categories = _mapper.Map<List<CategoryTypesDto>>(categoryList)
            };
        }
    }
}
