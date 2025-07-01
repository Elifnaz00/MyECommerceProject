using MyProject.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.UnıtOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyProjectContext _context;

        public UnitOfWork(MyProjectContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();  
        }
    }
}
