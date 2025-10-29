using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Dashboard.Queries.Response
{
    public class GetDashboardDataQueryResponse
    {
        public int TotalProduct { get; set; }

        public int TotalOrder { get; set; }

        public decimal TotalAmountOrder { get; set; }
        public string Message { get; set; } 
        public bool IsSuccess { get; set; } 


    }
}
