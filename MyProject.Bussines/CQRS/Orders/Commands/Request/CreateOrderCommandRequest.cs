using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Response;
using MyProject.DTO.DTOs.OrderDTOs;



namespace MyProject.Bussines.CQRS.Orders.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public CreateOrderDto? CreateOrderDto { get; set; }
      
    }
}
