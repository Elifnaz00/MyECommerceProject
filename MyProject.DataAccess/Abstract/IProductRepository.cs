

using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Abstract
{
    public interface IProductRepository : IBaseEntityRepository<Product>
    {
        IQueryable<Product> GetProductByCategory(Guid id);
        //Task<Product?> GetProductIncludeCategory(Guid id);
        IQueryable<Product> GetNewArrivalProducts();
        IQueryable<Product> GetFilteredProduct(FilteredProductDto filtered);
        int GetProductCount();
        Task<List<Product>> GetAvailableProductsAsync();
        Task<List<Product>> GetFinishedProductsAsync();


    }
}
