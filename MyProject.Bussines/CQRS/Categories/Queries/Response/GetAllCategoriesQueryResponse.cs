using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Categories.Queries.Response
{
    public class GetAllCategoriesQueryResponse
    {
        public Guid Id { get; set; }
        public string? CategoryName { get; set; }
        public string? ImageCategory { get; set; }
    }
}
