using Castle.Core.Logging;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;

using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DataAccess.Concrate
{
    public class EntranceRepository : GenericRepository<Entrance>, IEntranceRepository
    {
        public EntranceRepository(MyProjectContext myProjectContext) : base(myProjectContext)
        {
        }
    }
}
