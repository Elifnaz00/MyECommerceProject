using FluentValidation;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Contacts
{
    public class CreateContactCommandValidator: AbstractValidator<ContactUsCommandRequest>
    {
        public CreateContactCommandValidator() 
        {
            RuleFor(p => p.ContentMessage)
                
                .NotNull().NotEmpty().WithMessage("Lütfen Mesaj alanını boş bırakmayınız.")
                .MaximumLength(300).WithMessage("Mesaj içeriği en fazla 300 karakter olabilir");

            RuleFor(p => p.SenderMail)
                .NotNull().WithMessage("Lütfen Mail adresinizi giriniz.")
                .EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");

            RuleFor(p => p.Subject)
                .MaximumLength(200).WithMessage("Konu içeriği en fazla 200 karakter olabilir");

            
        }
    }
}
