using AutoMapper;
using MediatR;
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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductQueryResponse>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var value =  _productRepository.GetAll();
            var resultDto = _mapper.Map<IList<GetAllProductQueryResponse>>(value);
            return resultDto;
        }
    }
}
