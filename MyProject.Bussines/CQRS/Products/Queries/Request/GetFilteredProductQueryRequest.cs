using MediatR;
using MyProject.Bussines.CQRS.Products.Queries.Response;
using MyProject.DTO.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Bussines.CQRS.Products.Queries.Request
{
    public class GetFilteredProductQueryRequest: IRequest<IList<GetFilteredProductQueryResponse>>
    {
        public FilteredProductDto Filter { get; }

        public GetFilteredProductQueryRequest(FilteredProductDto filteredProductDto)
        {
            Filter = filteredProductDto;
        }

    }
}
