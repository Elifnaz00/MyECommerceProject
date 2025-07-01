using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Response
{
    public class GetNewProductsQueryResponse
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long? Price { get; set; }
        public string? ImageUrl { get; set; }
       
        //public DateTime CreatedDate { get; set; }







    }
}
