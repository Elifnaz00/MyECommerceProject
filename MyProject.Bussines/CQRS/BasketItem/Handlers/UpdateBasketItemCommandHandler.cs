using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Commands.Response;
using MyProject.Bussines.Services;
using MyProject.DataAccess.UnıtOfWorks;
using MyProject.DTO.Models.BasketItemViewModel;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, UpdateBasketItemCommandResponse>
    {
        private readonly IBasketItemService _basketItemService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBasketItemCommandHandler(IBasketItemService basketItemService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _basketItemService = basketItemService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateBasketItemCommandResponse> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
           
            var mappedValue= _mapper.Map<UpdateBasketItemViewModel>(request);

            var updated= await _basketItemService.UpdateBasketItemAsync(mappedValue);
                if(!updated)
                {
                    return new UpdateBasketItemCommandResponse
                    {
                        IsSuccess = false,
                        Message = "Sepet güncellenemedi..."
                    };
                }

            await _unitOfWork.SaveChangesAsync();
            return new UpdateBasketItemCommandResponse
            {
                IsSuccess = true,
                Message = "Sepet Güncellemesi başarılı..."
            };
        }
    }
}
