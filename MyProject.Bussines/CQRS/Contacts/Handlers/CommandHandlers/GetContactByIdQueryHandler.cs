using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyProject.Bussines.CQRS.Contacts.Queries.Request;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Abouts.Queries.Response;
using MyProject.DTO.DTOs.ContactDTOs;
using MyProject.Entity.Entities;

namespace MyProject.Bussines.CQRS.Contacts.Handlers.CommandHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQueryRequest, GetContactByIdQueryResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetContactByIdQueryResponse> Handle(GetContactByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var  contactValue = await  _contactRepository.GetByIdAsync(request.Id);
            var mappingContactValue= _mapper.Map<ContactDto>(contactValue);
            return new GetContactByIdQueryResponse
            {
                ContactDto = mappingContactValue,
                
            };
           
        }
    }
}
