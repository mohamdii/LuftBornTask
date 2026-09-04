using LuftBornTask.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Commands
{
    public record DeleteProductCommand(int Id) : IRequest<ProductDto>;

}
