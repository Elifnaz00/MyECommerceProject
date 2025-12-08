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
    public class GetFinishedProductQueryHandler : IRequestHandler<GetFinishedProductQueryRequest, List<ProductListDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetFinishedProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetFinishedProductQueryRequest request, CancellationToken cancellationToken)
        {
            var finishedProductList = await _productRepository.GetFinishedProductsAsync();
            var mappedFinishedProductList = _mapper.Map<List<ProductListDto>>(finishedProductList);
            return mappedFinishedProductList;
        }
    }
}
