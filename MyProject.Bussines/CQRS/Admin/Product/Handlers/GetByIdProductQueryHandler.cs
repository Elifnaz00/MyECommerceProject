using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Product.Queries.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
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
        private readonly IMapper _mapper;

        public GetByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductEditDto> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            
            var productItem = await _productRepository.GetProductWithCategoryByIdAsync(request.Id);
            if(productItem is null)
               throw new NotFoundException("Product not found");

            var productEditDto = _mapper.Map<ProductEditDto>(productItem);
            return productEditDto;
        }
    }
}
