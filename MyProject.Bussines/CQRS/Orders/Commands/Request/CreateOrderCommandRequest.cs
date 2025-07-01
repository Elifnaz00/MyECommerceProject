using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Orders.Commands.Response;
using MyProject.DataAccess.Abstract;

using MyProject.Entity.Entities;
using MyProject.TokenDTOs.DTOs.OrderDTOs;



namespace MyProject.Bussines.CQRS.Orders.Commands.Request
{
    public class CreateOrderCommandRequest : IRequest<CreateOrderCommandResponse>
    {
        public CreateOrderDto CreateOrderDto { get; set; }


    }
}
