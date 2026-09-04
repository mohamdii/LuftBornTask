using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Commands
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, ProductDto>
    {
        private readonly IProductService _productService;

        public AddProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            return await _productService.CreateAsync(request.Dto);
        }
    }
}
