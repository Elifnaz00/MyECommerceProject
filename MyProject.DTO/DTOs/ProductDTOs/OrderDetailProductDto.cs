﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Entity.Entities;

namespace MyProject.DTO.DTOs.ProductDTOs
{
    public class OrderDetailProductDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public long Price { get; set; }
        public string? ImageUrl { get; set; }

    }
}
