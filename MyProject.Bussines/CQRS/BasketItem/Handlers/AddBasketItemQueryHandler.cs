using System.Security.Claims;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyProject.Bussines.CQRS.BasketItem.Queries.Request;
using MyProject.Bussines.Services;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class AddBasketItemQueryHandler : IRequestHandler<AddBasketItemQueryRequest, AddBasketItemQueryResponse>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBasketItemService _basketItemService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
       
        public AddBasketItemQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, IBasketItemService basketItemService, IBasketService basketService)
        {
            _httpContextAccessor = httpContextAccessor;
            _basketItemService = basketItemService;
            _basketService = basketService;
            _mapper = mapper;

        }

        public async Task<AddBasketItemQueryResponse> Handle(AddBasketItemQueryRequest request, CancellationToken cancellationToken)
        {
            // Kullanıcının kimliğini HttpContext üzerinden al
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
            {
                return new()
                {
                    IsSuccess = false,
                    Message = "Kullanıcı kimliği bulunamadı."
                };
            }

            var basketByUser = await _basketService.GetBasketByUserServiceAsync(userId); // Kullanıcının sepetini alır. Eğer sepet yoksa yeni bir sepet oluşturur.  

            if (basketByUser == null)
            {
                var newBasket = new Basket
                {
                    AppUserId = userId,
                    Active = true
                };

                var newBasketAdded = await _basketService.AddBasketAsync(newBasket);

               
                AddBasketItemViewModel newBasketAddedModel = new()
                {
                    ProductId = request.ProductId,
                    BasketId = newBasketAdded.Id,
                    Quantity = 1
                };


                var addedItem = await _basketItemService.AddBasketItemAsync(newBasketAddedModel); // Sepete yeni ürün ekler.  
                if (addedItem == null)
                {
                    return new()
                    {
                        IsSuccess = false,
                        Message = "Ürün sepete eklenemedi."
                    };
                }
                return new()
                {
                    BasketItem = _mapper.Map<BasketItemDto>(addedItem),
                    IsSuccess = true,
                    Message = "Ürün sepetinize eklendi."
                };
            }

            var checkedProductInBasket = await _basketItemService.GetBasketItemProductAsync(basketByUser.Id, request.ProductId);
            if (checkedProductInBasket == null)
            {
                // Kullanıcının sepetinde requestten gelen ürün yoksa yeni basket ıtem ekler.  
                AddBasketItemViewModel value7 = new()
                {
                    ProductId = request.ProductId,
                    BasketId = basketByUser.Id,
                    Quantity = 1,

                };

                var addedItem = await _basketItemService.AddBasketItemAsync(value7);
                if(addedItem == null)
                {
                    return new AddBasketItemQueryResponse
                    {
                        IsSuccess = false,
                        Message = "Ürün sepete eklenemedi."
                    };
                }


                return new AddBasketItemQueryResponse
                {
                    BasketItem= _mapper.Map<BasketItemDto>(value7),
                    IsSuccess = true,
                    Message = "Ürün sepetinize eklendi."
                };
            }

            // Kullanıcının sepetinde requestten gelen ürün varsa, miktarını günceller.  
            UpdateBasketItemViewModel updateItemModel = new()
            {
                Id = checkedProductInBasket.Id, // Sepetteki ürünün ID'si  
            };

            var updateSuccess = await _basketItemService.UpdateQuantityAsync(updateItemModel);
            return new AddBasketItemQueryResponse
            {
                IsSuccess = updateSuccess,
                Message = updateSuccess ? "Ürün sepete eklendi." : "Ürün miktarı güncellenemedi."
            };

        }

    }
}

