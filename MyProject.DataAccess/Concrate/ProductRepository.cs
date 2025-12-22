using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.DTO.DTOs.ProductDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    { 
        private readonly MyProjectContext _context;
        
        public ProductRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _context = myProjectContext;
        }

       
        public IQueryable<Product> GetFilteredProduct(FilteredProductDto filtered)
        {

            var query = _context.Products.AsQueryable();

            if (filtered.Color != null) {

                query=  query.Where(x => x.Color == filtered.Color);
            }

            if (filtered.Price != null) { 
                query=  query.Where(x=> x.Price == filtered.Price);   
            }

            if (filtered.Size != null) { 
                query=  query.Where(x=>x.Size == filtered.Size); 

            }

            if (filtered.Category != null) { 
                 query= query.Include(x => x.Category).Where(x=> x.Category.CategoryName == filtered.Category);
            }
            
           return query;
        
        }

        public IQueryable<Product> GetNewArrivalProducts()
        {
            var value = _context.Products.OrderByDescending(x => x.CreateDate).Take(8);   
            return value;
        }


        public IQueryable<Product> GetProductByCategory(Guid categoryId)
        {
          
            return _context.Products.Where(x => x.CategoryId == categoryId);
        }

        public int GetProductCount()
        {
            return _context.Products.AsNoTracking().Count();
        }   

        public async Task<List<Product>> GetAvailableProductsAsync()
        {
            return await _context.Products.AsNoTracking().Include(m => m.Category).Where(a => a.Stock > 0).ToListAsync();
        }

        public async Task<List<Product>> GetFinishedProductsAsync()
        {
            return await _context.Products.AsNoTracking().Include(m => m.Category).Where(a => a.Stock == 0).ToListAsync();
        }


        public async Task<Product?> GetProductWithCategoryByIdAsync(Guid id)
        {
            return await _context.Products.AsNoTracking().Include(m => m.Category).FirstOrDefaultAsync(p => p.Id == id);
        }



    }
}
