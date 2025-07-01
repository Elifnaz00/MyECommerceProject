using System.ComponentModel.DataAnnotations;

namespace MyProject.WebUI.Models.ContactModel
{
    public class ContactUsViewModel
    {

    
        public string? ContentMessage { get; set; }
        public string? SenderName { get; set; }


        public string? SenderMail { get; set; }


        public string? Subject { get; set; }


    }
}
