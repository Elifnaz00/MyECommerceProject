using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
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
    public class GetProductDetailQueryRequestHandler : IRequestHandler<GetProductDetailQueryRequest, GetProductDetailQueryResponse>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
       

        public GetProductDetailQueryRequestHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductDetailQueryRequest> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
           
        }

        public async Task<GetProductDetailQueryResponse> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _productRepository.GetByIdAsync(request.Id);


            if (value is null)
            {    
                throw new KeyNotFoundException("Ürün bulunamadı.");
            }

            var getProductDetailQueryResponse = _mapper.Map<GetProductDetailQueryResponse>(value);

            return getProductDetailQueryResponse;

        }
    }
}
