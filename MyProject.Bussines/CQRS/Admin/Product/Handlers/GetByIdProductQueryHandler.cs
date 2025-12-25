using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Product.Queries.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Handlers
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, ProductEditDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ProductEditDto> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            var productItem = await _productRepository.GetProductWithCategoryByIdAsync(request.Id);
            if(productItem is null)
               throw new NotFoundException("Product not found");

            var allCategoriesList=  _categoryRepository.GetAll().ToList();

            var productEditDto = _mapper.Map<ProductEditDto>(productItem);
            productEditDto.CategoryDtos = _mapper.Map<List<CategoryDto>>(allCategoriesList);
            return productEditDto;
        }
    }
}
