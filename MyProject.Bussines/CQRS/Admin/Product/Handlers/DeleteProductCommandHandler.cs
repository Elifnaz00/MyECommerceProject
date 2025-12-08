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
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            var hasProduct= await _productRepository.FindByIdAsync(request.Id);
            if(hasProduct is null)
            {
                throw new NotFoundException("Silinecek ürün bulunamadı");
            }
            await _productRepository.DeleteAsync(hasProduct);
            return Unit.Value;
        }
    }
}
