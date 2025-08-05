using AutoMapper;
using MyProject.Bussines.CQRS.Abouts.Queries.Response;
using MyProject.Bussines.CQRS.AppUsers.Commands.Request;
using MyProject.Bussines.CQRS.Categories.Queries.Response;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;
using MyProject.Bussines.CQRS.Orders.Commands.Request;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using MyProject.TokenDTOs.DTOs.EntranceDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Bussines.CQRS.Products.Queries.Request;
using MyProject.DTO.DTOs.ContactDTOs;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.Bussines.CQRS.Baskets.Queries.Request;
using MyProject.DTO.DTOs.BasketItemDTOs;
using MyProject.DTO.DTOs.BasketDTOs;

using MyProject.DTO.Models.BasketItemViewModel;
using MyProject.Bussines.CQRS.BasketItem.Commands.Request;

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
            CreateMap<Order,OrderDto>().ReverseMap();
            CreateMap<Basket, AddBasketItemDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<Basket, AddBasketDto>().ReverseMap();

            CreateMap<Order, CreateOrderCommandRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoriesQueryResponse>().ReverseMap();
            CreateMap<Product, GetAllProductQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductByCategoryQueryResponse>().ReverseMap();
            CreateMap<Product, GetProductDetailQueryResponse>().ReverseMap();
            CreateMap<Product, GetNewProductsQueryResponse>().ReverseMap();
            CreateMap<Product, GetFilteredProductQueryResponse>().ReverseMap();
            CreateMap<WhyUs, GetAboutQueryResponse>().ReverseMap();
            CreateMap<Contact, ContactUsCommandRequest>().ReverseMap();
            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<Basket, AddBasketQueryRequest>().ReverseMap();
            CreateMap<BasketItem, AddBasketItemCommandRequest>().ReverseMap();

            CreateMap<BasketItem, AddBasketItemViewModel>().ReverseMap();
            CreateMap<BasketItem, UpdateBasketItemViewModel>().ReverseMap();
            
           






        }
    }
}
