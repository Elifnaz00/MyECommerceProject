using FluentValidation;
using MyProject.WebUI.Models.ContactModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.WebUI.Validations
{
    public class ContactUsViewModelValidator: AbstractValidator<ContactUsViewModel>
    {
        public ContactUsViewModelValidator() 
        {
            

            RuleFor(p => p.ContentMessage)
              .NotNull().WithMessage("Lütfen Mesaj alanını boş bırakmayınız.")
              .MaximumLength(300).WithMessage("Mesaj içeriği en fazla 300 karakter olabilir");

            RuleFor(p => p.SenderMail)
                .NotNull().WithMessage("Lütfen Mail adresinizi giriniz.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(p => p.Subject)
                .MaximumLength(200).WithMessage("Konu içeriği en fazla 200 karakter olabilir");


            RuleFor(p => p.SenderName)
                .NotNull().WithMessage("Lütfen isminizi giriniz.");
        }    
    }
    
}
