using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Queries.Request;
using MyProject.Bussines.CQRS.BasketItem.Queries.Response;
using MyProject.Bussines.Services;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class GetBasketTotalQueryHandler : IRequestHandler<GetBasketTotalQueryRequest, GetBasketTotalQueryResponse>
    {
        private readonly IBasketItemService _basketItemService;

        public GetBasketTotalQueryHandler(IBasketItemService basketItemService)
        {
            _basketItemService = basketItemService;
        }

        public async Task<GetBasketTotalQueryResponse> Handle(GetBasketTotalQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                decimal total = await _basketItemService.CalculateBasketTotalServiceAsync(request.BasketId);

                return new GetBasketTotalQueryResponse() { TotalAmount = total, IsSuccess= true, Message="Toplam fiyat başarıyla getirildi."};
            }
            catch (Exception ex)
            {
                return new GetBasketTotalQueryResponse()
                {
                    IsSuccess = false,
                    Message = $"An error occurred while calculating the basket total: {ex.Message}"
                };
            }
              
        }
    }
}
