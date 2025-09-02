using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.DTO.DTOs.ContactDTOs
{
    public class ContactDto
    {
        public Guid Id { get; init; }
        public DateTime CreateDate { get; set; }
        public string? ContentMessage { get; set; }
        public string? SenderName { get; set; }
        public string? SenderMail { get; set; }
        public string? Subject { get; set; }

    }
}
