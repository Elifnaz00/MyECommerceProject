﻿using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Response
{
    public class GetAllProductQueryResponse
    {
        public Guid Id  { get; set; }
        public string? Title { get; set; }

        public int Stock { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }

        public string? Size { get; set; }

        public string? Color { get; set; }


        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }

    }
}
