using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<Basket> AddBasketAsync(Basket basket)
        {
            return await _basketRepository.AddAsync(basket);
        }

        public async Task<IEnumerable<BasketItem>> GetActiveBasketItemsByUserIdServiceAsync(string userId)
        {
            return await _basketRepository.GetActiveBasketItemsByUserIdAsync(userId);

        }

        public async Task<Basket> GetBasketByUserServiceAsync(string userId)
        {
            var value = await _basketRepository.GetBasketByUserAsync(userId);
            
            return value;

        }
    }
}
