
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;

using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly MyProjectContext _context; 
        public CategoryRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
            _context = myProjectContext;
        }

        public async Task<List<Category>> GetCategoryTypesListAsync()
        {
            return await _context.Categories.Select(u => new Category
            {
                Id = u.Id,
                CategoryName = u.CategoryName
            }).ToListAsync();
        }
    }
}
