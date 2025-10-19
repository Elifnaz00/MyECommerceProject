using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.BasketItem.Queries.Response
{
    public class GetBasketTotalQueryResponse
    {
        public decimal TotalAmount { get; set; }    

        public bool IsSuccess { get; set; } 

        public string Message { get; set; } 
    }
}
