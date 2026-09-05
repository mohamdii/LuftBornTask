using LuftBornTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.Commands
{
    public record UpdateProductCommand(int Id, UpdateProductDto Dto) : IRequest<ProductDto>;
}
