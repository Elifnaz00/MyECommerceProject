using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    public abstract class BaseEntity
    {
        
        public Guid Id { get; init; } 
        public DateTime CreateDate { get; set; } 

        public bool IsDeleted { get; set; } = false;

    

       
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        } 
       
        
       
    }
}
