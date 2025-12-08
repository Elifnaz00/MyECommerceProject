using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Admin.Product.Command.Request
{
    public class DeleteProductCommandRequest : IRequest<Unit>
    {

        public Guid Id { get; set; }
    }
}
