using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;
        private readonly IMapper _mapper;

        public BasketItemService(IBasketItemRepository basketItemRepository, IMapper mapper)
        {
            _basketItemRepository = basketItemRepository;
            _mapper = mapper;
        }


        public async Task<BasketItem?> AddBasketItemAsync(AddBasketItemViewModel addBasketItemViewModel)
        {
            try
            {
                var entity = _mapper.Map<BasketItem>(addBasketItemViewModel);
                var addedEntity = await _basketItemRepository.AddItemBasketAsync(entity);
                

                return addedEntity?.Id != Guid.Empty ? addedEntity : null;
            }
            catch
            {
                return null;
            }

        }


        public async Task<BasketItem> GetBasketItemProductAsync(Guid basketId, Guid productId)
        {
            return await _basketItemRepository.GetByUserIdBasketItemAsync(basketId, productId);
        }

      

        public async Task<bool> UpdateQuantityAsync(UpdateBasketItemViewModel updateBasketItemViewModel)
        {
            var existingItem = await _basketItemRepository.GetByIdAsync(updateBasketItemViewModel.Id);
            if (existingItem == null) return false;

            existingItem.Quantity += 1; 

            return _basketItemRepository.Update(existingItem);
           
        }

       
        public async Task<bool> RemoveBasketItemAsync(Guid basketItemId, string userId)
        {
             return await _basketItemRepository.DeleteItemBasketAsync(basketItemId, userId);
               
        }


        public async Task<bool> UpdateBasketItemAsync(UpdateBasketItemViewModel updateBasketItemViewModel)
        {
            var existingItem = await _basketItemRepository.GetByIdAsync(updateBasketItemViewModel.Id);
            if (existingItem == null || updateBasketItemViewModel.Quantity < 1)
                return false;
           
            existingItem.Quantity = updateBasketItemViewModel.Quantity;
            return true;
           

        }


    }
}
