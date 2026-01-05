using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Product.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Handlers
{
    public class GetDetailProductQueryHandler : IRequestHandler<GetDetailProductQueryRequest, ProductDetailDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetDetailProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<ProductDetailDto> Handle(GetDetailProductQueryRequest request, CancellationToken cancellationToken)
        {
            var productDetail= _productRepository.GetByIdAsync(request.Id);  
            return Task.FromResult(_mapper.Map<ProductDetailDto>(productDetail));
        }
    }
}
