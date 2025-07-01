using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyProject.DTO.DTOs.ContactDTOs;

namespace MyProject.Bussines.CQRS.Contacts.Queries.Request
{
    public class GetContactByIdQueryRequest : IRequest<GetContactByIdQueryResponse>
    {
        public Guid Id { get; set; }
    }


    public class GetContactByIdQueryResponse
    {
        public ContactDto ContactDto { get; set; }

        public int StatusCode { get; set; }     

        public string Message { get; set; }


    }
}