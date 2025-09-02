using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MyProject.Bussines.CQRS.Orders.Queries.Request;
using MyProject.Bussines.CQRS.Orders.Queries.Response;
using MyProject.DataAccess.Abstract;

namespace MyProject.Bussines.CQRS.Orders.Handlers
{
    public class GetUserOrderQueryHandler : IRequestHandler<GetUserOrderQueryRequest, GetUserOrderQueryResponse>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetUserOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<GetUserOrderQueryResponse> Handle(GetUserOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
               return new Task<GetUserOrderQueryResponse>(() => new GetUserOrderQueryResponse
               {
                   IsSuccess = false,
                   Message = "Kullanıcı kimliği bulunamadı."
               });
            }

            //var orders = _orderRepository.GetAllOrdersByUserId(userId);
        }
    }
}
