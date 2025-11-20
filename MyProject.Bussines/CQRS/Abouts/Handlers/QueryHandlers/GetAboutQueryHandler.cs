using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyProject.Bussines.CQRS.Abouts.Queries.Request;
using MyProject.Bussines.CQRS.Abouts.Queries.Response;
using MyProject.DataAccess.Abstract;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Abouts.Handlers.QueryHandlers
{
    public class GetAboutQueryHandler : IRequestHandler<GetAboutQueryRequest, IList<GetAboutQueryResponse>>
    {

        private readonly IAboutRepository _aboutrepository;
        private readonly IMapper _mapper;

        public GetAboutQueryHandler(IAboutRepository aboutrepository, IMapper mapper)
        {
            _aboutrepository = aboutrepository;
            _mapper = mapper;
        }

        public async Task<IList<GetAboutQueryResponse>> Handle(GetAboutQueryRequest request, CancellationToken cancellationToken)
        {
            var value=  _aboutrepository.GetAll();
            var aboutList= await value.ToListAsync();

            return _mapper.Map<IList<GetAboutQueryResponse>>(aboutList);
           


        }
    }
}
