using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using MyProject.Bussines.CQRS.BasketItem.Commands;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Commands.Response;
using MyProject.Bussines.Services;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class DeleteBasketItemCommandHandler : IRequestHandler<DeleteBasketItemCommandRequest, DeleteBasketItemCommandResponse>
    {
        private readonly IBasketItemService _basketItemService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteBasketItemCommandHandler(IHttpContextAccessor httpContextAccessor,IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<DeleteBasketItemCommandResponse> Handle(DeleteBasketItemCommandRequest request, CancellationToken cancellationToken)
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

            var result = await _basketItemService.RemoveBasketItemAsync(request.Id, userId);
            return new()
            {
                IsSuccess = result,
                Message = result ? "Seçili ürün başarıyla silindi." : "Seçili ürün silinemedi."
            };
        }
    }
}
