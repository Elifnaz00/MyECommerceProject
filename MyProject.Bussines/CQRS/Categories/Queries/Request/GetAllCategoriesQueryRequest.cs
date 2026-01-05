using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.DataAccess.Abstract;
using MyProject.DataAccess.Context;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Categories.Queries.Request
{
    public class GetAllCategoriesQueryRequest : IRequest<List<CategoryListDTO>>
    { 

    }


}
