using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Product.Command.Request;
using MyProject.Bussines.Exceptions;
using MyProject.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var hasDeleteProduct = await _productRepository.GetByIdAsync(request.Id);

            if (hasDeleteProduct != null)
            {
                var mappedProduct= _mapper.Map<MyProject.Entity.Entities.Product>(request.UpdateProductDto);
                
                await _productRepository.UpdateAsync(mappedProduct);
                return Unit.Value;

            }
            throw new NotFoundException("Güncellenecek ürün bulunamadı");
            
        }
    }
}
