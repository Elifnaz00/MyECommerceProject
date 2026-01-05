using MediatR;
using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Category.Queries.Request
{
    public class GetCategoriesQueryRequest : IRequest<List<CategoryDto>>
    {
    }
}
