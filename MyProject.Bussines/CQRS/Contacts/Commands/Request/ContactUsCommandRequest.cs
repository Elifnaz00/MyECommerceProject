using MediatR;
using MyProject.DTO.DTOs.ContactDTOs;
using MyProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Contacts.Commands.Request
{
    public class ContactUsCommandRequest : IRequest<ContactUsCommandResponse>
    {

        public string ContentMessage { get; set; }
        public string SenderName { get; set; }


        public string SenderMail { get; set; }


        public string? Subject { get; set; }
    }



    public class ContactUsCommandResponse
    {
        public ContactDto ContactDto { get; set; }
    }
}
