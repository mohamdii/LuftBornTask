using LuftBornTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<ProductDto>>;
}
