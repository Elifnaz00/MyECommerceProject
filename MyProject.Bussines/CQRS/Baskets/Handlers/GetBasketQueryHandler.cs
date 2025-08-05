using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;
using MyProject.Bussines.CQRS.Baskets.Queries.Response;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;
using MyProject.Entity.Enums;

namespace MyProject.Bussines.CQRS.Baskets.Handlers
{
    public class GetBasketQueryHandler: IRequestHandler<GetBasketQueryRequest, GetBasketQueryResponse>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IBasketRepository _basketRepository;
        private readonly IMapper _mapper;   

        public GetBasketQueryHandler(UserManager<AppUser> userManager, IBasketRepository basketRepository, IMapper mapper)
        {
            _userManager = userManager;
            _basketRepository = basketRepository;
            _mapper = mapper;

        }

        public async Task<GetBasketQueryResponse> Handle(GetBasketQueryRequest request, CancellationToken cancellationToken)
        {
           
            var basketItems= await _basketRepository.GetActiveBasketItemsByUserIdAsync(request.UserId);
            
            if (basketItems is null)
            {
                return new GetBasketQueryResponse
                {
                    BasketItems = null,
                    Message= "Kullanıcıya ait aktif sepet bulunamadı.",
                    IsSuccess = false,
                    BasketStatus = BasketStatus.NotFound,
                };
            }
            if(!basketItems.Any())
            {
                return new GetBasketQueryResponse
                {
                    BasketItems = new List<BasketItemDto>(),
                    Message = "Sepetinizde ürün bulunmamaktadır.",
                    IsSuccess = true,
                    BasketStatus = BasketStatus.Empty,
                };
            }
          
            var basketItemDto = _mapper.Map<IList<BasketItemDto>>(basketItems);

            return new GetBasketQueryResponse
            {
                BasketItems = basketItemDto,
                IsSuccess= true,
                BasketStatus = BasketStatus.HasItems,
               

            };
            

        }
    }
    
}
