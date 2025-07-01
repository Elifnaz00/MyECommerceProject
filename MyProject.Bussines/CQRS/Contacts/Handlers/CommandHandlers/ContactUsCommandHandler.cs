using AutoMapper;
using MediatR;
using MyProject.DataAccess.Abstract;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;
using MyProject.DTO.DTOs.ContactDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Contacts.Handlers.CommandHandlers
{
    public class ContactUsCommandHandler : IRequestHandler<ContactUsCommandRequest, ContactUsCommandResponse>
    {

        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactUsCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactUsCommandResponse> Handle(ContactUsCommandRequest request, CancellationToken cancellationToken)
        {
            var contactValue = _mapper.Map<Contact>(request);
            var addedContactValue = await _contactRepository.AddAsync(contactValue);
            return new ContactUsCommandResponse
            {
                ContactDto = _mapper.Map<ContactDto>(addedContactValue)
            };
        }
    }
}
