using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public class Category: BaseEntity
    {
        public string? CategoryName { get; set; }

        public string? ImageCategory { get ; set; }  
        public virtual ICollection<Product>? Products { get; set; }
    }
}
