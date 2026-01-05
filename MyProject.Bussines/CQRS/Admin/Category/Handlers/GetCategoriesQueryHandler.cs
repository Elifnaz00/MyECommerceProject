using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Admin.Category.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.DTO.DTOs.AdminDTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Category.Handlers
{
    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQueryRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public Task<List<CategoryDto>> Handle(GetCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_mapper.Map<List<CategoryDto>>(_categoryRepository.GetAll()));
        }
    }
}
