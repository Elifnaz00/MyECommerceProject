using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.Services
{
    public interface IBasketItemService
    {
        Task<BasketItem> GetBasketItemProductAsync(Guid basketId, Guid productId);

        Task<BasketItem?> AddBasketItemAsync(AddBasketItemViewModel viewModel);

        Task<bool> RemoveBasketItemAsync(Guid basketItemId, string userId);

        Task<bool> UpdateQuantityAsync(UpdateBasketItemViewModel UpdateBasketItemViewModel);

        Task<bool> UpdateBasketItemAsync(UpdateBasketItemViewModel updateBasketItemViewModel);

    }
}
