
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
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
        }
    }
}
