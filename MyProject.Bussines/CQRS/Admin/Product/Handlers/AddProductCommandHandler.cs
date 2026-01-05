using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Product.Command.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Handlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
           await _productRepository.AddAsync(_mapper.Map<Entity.Entities.Product>(request.AdminAddProductDto));
           return Unit.Value;
        }
    }
}
