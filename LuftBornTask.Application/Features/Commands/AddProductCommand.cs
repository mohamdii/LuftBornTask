using LuftBornTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.Commands
{
    public record AddProductCommand(CreateProductDto Dto) : IRequest<ProductDto>;

}
