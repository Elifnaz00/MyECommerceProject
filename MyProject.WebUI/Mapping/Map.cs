using AutoMapper;
using MyProject.DTO.DTOs.AdminDTOs.ProductDto;
using MyProject.DTO.DTOs.AdminDTOs.UserDto;
using MyProject.DTO.DTOs.OrderDTOs;
using MyProject.DTO.DTOs.OrderStatusDTOs;
using MyProject.Entity.Entities;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using MyProject.WebUI.Models.AdminModel.OrderModel;
using MyProject.WebUI.Models.CategoryModel;
using MyProject.WebUI.Models.ContactModel;
using MyProject.WebUI.Models.EntranceModel;
using MyProject.WebUI.Models.ProductModel;
using MyProject.WebUI.Models.ShoppingCartModel;
using MyProject.WebUI.Models.UserModel;

namespace MyProject.WebUI.Mapping
{
    public class Map: Profile
    {
        public Map() {
            CreateMap<Entrance, CreateEntranceViewModel>().ReverseMap();
            CreateMap<CategoryListDTO, CategoryListViewModel>().ReverseMap();
            CreateMap<Product, ProductListViewModel>().ReverseMap();
            CreateMap<Product, ProductByCategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductDetailViewModel>().ReverseMap();
            CreateMap<Product, ProductNewViewModel>().ReverseMap();
            CreateMap<Product, ShoppingCartProductViewModel>().ReverseMap();
            CreateMap<Basket, ShoppingCartGetItemsViewModel>().ReverseMap();
            CreateMap<Basket, ShoppingCartViewModel>().ReverseMap();

            CreateMap<UserListDto, CustomerListViewModel>();
           
            CreateMap<OrderListDto, OrderListModel>();
            CreateMap<OrderStatusDto, OrderStatusViewModel>();
            CreateMap<ProductListDto, ProductListViewModel>();  
              

           
         
            
             
          
           


        }    

    }
}
