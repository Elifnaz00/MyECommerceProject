using MyProject.DTO.DTOs.BasketItemDTOs;

namespace MyProject.WebUI.Models.BasketItemModel
{
    public class AddToBasketItemViewModel
    {
        public BasketItemDto BasketItem { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

    }
}
