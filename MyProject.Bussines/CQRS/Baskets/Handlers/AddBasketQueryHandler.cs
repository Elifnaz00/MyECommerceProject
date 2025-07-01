using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.BasketDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Baskets.Handlers
{
    public class AddBasketQueryHandler: IRequestHandler<AddBasketQueryRequest, AddBasketQueryResponse>
    {
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;

        public AddBasketQueryHandler(IBasketRepository basketRepository, IMapper mapper)
        {
            _basketRepository = basketRepository;
            _mapper = mapper;
        }

        public async Task<AddBasketQueryResponse> Handle(AddBasketQueryRequest request, CancellationToken cancellationToken)
        {
             var mappedBasket =_mapper.Map<Basket>(request);

            var basket= await _basketRepository.AddAsync(mappedBasket);
            return new AddBasketQueryResponse
            {
                AddBasketDto = _mapper.Map<AddBasketDto>(basket),
                IsSuccess = true,
                Message = "Sepetiniz Başarıyla Oluşturuldu",

            };
        }
    }   
    
}
