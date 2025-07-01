using Azure.Core;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyProject.Bussines.CQRS.Contacts.Queries.Request;
using MyProject.Bussines.CQRS;
using MyProject.Bussines.CQRS.Contacts.Commands.Request;
using MyProject.WebUI.Models.ContactModel;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace MyProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IValidator<ContactUsCommandRequest> _validator;

        public ContactController(IMediator mediator, IValidator<ContactUsCommandRequest> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }





        [HttpPost]
        public async Task<IActionResult> ContactUs([FromBody]ContactUsCommandRequest contactUsCommandRequest)
        {

            ValidationResult validationResult = await _validator.ValidateAsync(contactUsCommandRequest);
            validationResult.AddToModelState(ModelState, null);

            if (!validationResult.IsValid)
            {
                var errors = ModelState
                .Where(x => x.Value.Errors.Any())
                .ToDictionary(
                    x => x.Key,
                    x => x.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return BadRequest(new { Errors = errors });

               

            }
            var contactResponse = await _mediator.Send(contactUsCommandRequest);
            
            return CreatedAtAction(nameof(GetContactById), new { id = contactResponse.ContactDto.Id }, contactResponse.ContactDto);
            
          
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(Guid id)
        {
            var contact = await _mediator.Send(new GetContactByIdQueryRequest { Id = id });
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }
    }
}
