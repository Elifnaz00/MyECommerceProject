using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Products.Commands;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Products.Handlers.CommandHandler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
    {
        readonly IMapper mapper;
        readonly IProductRepository productRepository;

        public AddProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            this.mapper = mapper;
            this.productRepository = productRepository;
        }

        public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product= mapper.Map<Product>(request.ProductValues);
            var productValue= await productRepository.AddAsync(product);
            return new AddProductCommandResponse
            {
                ProductDto = mapper.Map<ProductDto>(productValue),
                
            };


        }

       
    }

}
