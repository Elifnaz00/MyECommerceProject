using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Entity.Entities
{
    //Order-Dependent Entity(bağımlı varlık), Basket-Principal Entity(asıl varlık)
    public class Order : BaseEntity
    {
       

        public int Piece {  get; set; }
        public string? Addres { get; set; }

        public Basket Basket { get; set; } 

       
    }
}
