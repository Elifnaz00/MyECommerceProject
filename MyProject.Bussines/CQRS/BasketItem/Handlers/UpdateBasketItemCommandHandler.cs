using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.Services;
using MyProject.DTO.Models.BasketItemViewModel;

namespace MyProject.Bussines.CQRS.BasketItem.Handlers
{
    public class UpdateBasketItemCommandHandler : IRequestHandler<UpdateBasketItemCommandRequest, bool>
    {
        private readonly IBasketItemService _basketItemService;
        private readonly IMapper _mapper;   

        public UpdateBasketItemCommandHandler(IBasketItemService basketItemService, IMapper mapper)
        {
            _basketItemService = basketItemService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateBasketItemCommandRequest request, CancellationToken cancellationToken)
        {
            var mappedValue= _mapper.Map<UpdateBasketItemViewModel>(request);
            return await _basketItemService.UpdateQuantityAsync(mappedValue);

        }
    }
}
