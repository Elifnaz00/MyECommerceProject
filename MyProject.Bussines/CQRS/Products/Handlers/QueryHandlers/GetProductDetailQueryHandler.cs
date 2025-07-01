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
        private readonly ILogger<GetProductDetailQueryRequest> _logger;

        public GetProductDetailQueryRequestHandler(IProductRepository productRepository, IMapper mapper, ILogger<GetProductDetailQueryRequest> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<GetProductDetailQueryResponse> Handle(GetProductDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var value = await _productRepository.GetByIdAsync(request.Id);


            if (value == null)
            {
                _logger.LogWarning("Ürün bulunamadı. ID: {Id}", request.Id);
                throw new KeyNotFoundException("Ürün bulunamadı.");
            }

            var getProductDetailQueryResponse = _mapper.Map<GetProductDetailQueryResponse>(value);

            return getProductDetailQueryResponse;

        }
    }
}
