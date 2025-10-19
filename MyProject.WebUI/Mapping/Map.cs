using AutoMapper;
using MyProject.Entity.Entities;

using MyProject.WebUI.Models.CategoryModel;
using MyProject.WebUI.Models.ContactModel;
using MyProject.WebUI.Models.EntranceModel;
using MyProject.WebUI.Models.OrderModel;
using MyProject.WebUI.Models.ProductModel;
using MyProject.WebUI.Models.ShoppingCartModel;

namespace MyProject.WebUI.Mapping
{
    public class Map: Profile
    {
        public Map() {
            CreateMap<Entrance, CreateEntranceViewModel>().ReverseMap();
            CreateMap<Category, CategoryListViewModel>().ReverseMap();
            CreateMap<Product, ProductListViewModel>().ReverseMap();
            CreateMap<Product, ProductByCategoryViewModel>().ReverseMap();
            CreateMap<Product, ProductDetailViewModel>().ReverseMap();
            CreateMap<Product, ProductNewViewModel>().ReverseMap();
            CreateMap<Product, ShoppingCartProductViewModel>().ReverseMap();
            CreateMap<Basket, ShoppingCartGetItemsViewModel>().ReverseMap();
            CreateMap<Basket, ShoppingCartViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();    


        }    

    }
}
