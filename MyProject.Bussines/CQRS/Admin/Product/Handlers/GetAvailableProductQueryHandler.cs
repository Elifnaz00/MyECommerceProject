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
    public class GetAvailableProductQueryHandler : IRequestHandler<GetAvailableProductQueryRequest, List<ProductListDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAvailableProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAvailableProductQueryRequest request, CancellationToken cancellationToken)
        {
           var availableProductList=  await _productRepository.GetAvailableProductsAsync();
           var mappedAvailableProductList= _mapper.Map<List<ProductListDto>>(availableProductList);
           return mappedAvailableProductList;
        }
    }
}
