
using AutoMapper;
using AutoMapper.Configuration.Conventions;
using MyProject.Bussines.CQRS.Abouts.Queries.Response;
using MyProject.Bussines.CQRS.Admin.Role.Commands.Request;
using MyProject.Bussines.CQRS.Admin.User.Queries.Request;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;
using MyProject.Bussines.CQRS.BasketItem.Queries.Request;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Products.Queries.Request;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using MyProject.DataAccess.UnıtOfWorks;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.DTO.DTOs.AdminDTOs.RoleDto;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using MyProject.DTO.DTOs.BasketDTOs;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.ContactDTOs;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.DTO.DTOs.OrderStatusDTOs;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.DTO.Models.AdminRoleViewModel;
using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.DTO.Models.OrderStatusViewModel;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using MyProject.TokenDTOs.DTOs.EntranceDTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Entrance, CreateEntranceDTO>().ReverseMap();
            CreateMap<Entrance, ListEntranceDTO>().ReverseMap();
            CreateMap<Entrance, EntranceDetailsDTO>().ReverseMap();
            CreateMap<Entrance, UpdateEntranceDTO>().ReverseMap();
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Contact,ContactDto>().ReverseMap();
            CreateMap<Order,CreatedOrderDto>().ReverseMap();
            CreateMap<Basket, AddBasketItemDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<Basket, AddBasketDto>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemDto>();
            CreateMap<AppRoleDto, AppRole>().ReverseMap();
            CreateMap<UpdateRoleDto, AppRole>().ReverseMap();

            CreateMap<UpdateBasketItemViewModel, UpdateBasketItemCommandRequest>().ReverseMap();
            
            CreateMap<Product, OrderDetailProductDto>().ReverseMap();
            CreateMap<Order, CreateOrderCommandRequest>().ReverseMap();

            
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductByCategoryQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductDetailQueryResponse>().ReverseMap();
            CreateMap<Product, GetNewProductsQueryResponse>().ReverseMap();
            CreateMap<Product, GetFilteredProductQueryResponse>().ReverseMap();
            CreateMap<Category, CategoryListDTO>();
            CreateMap<WhyUs, GetAboutQueryResponse>().ReverseMap();
            CreateMap<Contact, ContactUsCommandRequest>().ReverseMap();
            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<Basket, AddBasketQueryRequest>().ReverseMap();
            CreateMap<Basket, GetBasketTotalQueryRequest>().ReverseMap();
            CreateMap<BasketItem, AddBasketItemCommandRequest>().ReverseMap();
            CreateMap<BasketItem, AddBasketItemViewModel>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemViewModel>().ReverseMap();
            
            CreateMap<UpdateBasketItemDto, UpdateBasketItemViewModel>().ReverseMap();
            CreateMap<AppRole, AdminCreateRoleViewModel>().ReverseMap();      
            CreateMap<AdminCreateRoleViewModel, CreateRoleCommmandRequest>().ReverseMap();
            CreateMap<UpdateOrderStatusDto, OrderStatus>().ReverseMap();

            CreateMap<UserListDto, AppUser>().ReverseMap();
           

            CreateMap<Order, UserOrderDto>()
    .ForMember(dest => dest.OrderStatusName,
               opt => opt.MapFrom(src => src.OrderStatus.Name))
    .ForMember(dest => dest.OrderDetailBasketItemDtos,
               opt => opt.MapFrom(src => src.Basket.BasketItems));

            CreateMap<BasketItem, OrderDetailBasketItemDto>()
    .ForMember(dest => dest.Product,
               opt => opt.MapFrom(src => src.Product));

            CreateMap<Order, OrderDetailDto>()
                .ForMember(dest => dest.BasketItems,
               opt => opt.MapFrom(src => src.Basket.BasketItems))
                
            .ForMember(dest => dest.AppUserNameSurname,
               opt => opt.MapFrom(src => src.AppUser.NameSurname)); 


            CreateMap<CreateOrderDto, Order>()

            .ForMember(dest => dest.PaymentStatusId, opt => opt.MapFrom(src => Guid.Parse("11111111-1111-1111-1111-111111111111"))) // Pending
            .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(src => Guid.Parse("22222222-2222-2222-2222-222222222222"))); // Await Payment

            CreateMap<IUnitOfWork, UnitOfWork>().ReverseMap();

            CreateMap<Product, ProductListDto>();

            CreateMap<UpdateProductDto,Product>();
            CreateMap<OrderStatus, OrderStatusDto>();
            CreateMap<Order, OrderListDto>();


        }
    }
}
