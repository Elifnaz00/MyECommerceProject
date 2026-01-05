using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Categories.Queries.Request;
using MyProject.TokenDTOs.DTOs.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Categories.Handlers.QueryHandlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryListDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        async Task<List<CategoryListDTO>> IRequestHandler<GetAllCategoriesQueryRequest, List<CategoryListDTO>>.Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var value = _categoryRepository.GetAll();
            return _mapper.Map<List<CategoryListDTO>>(value);
            
        }
    }
}
