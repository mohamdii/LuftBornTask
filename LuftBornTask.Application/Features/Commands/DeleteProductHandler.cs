using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.Commands
{
    internal class DeleteProductHandler : IRequestHandler<DeleteProductCommand, ProductDto>
    {
        private readonly IProductService _productService;

        public DeleteProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.DeleteAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {request.Id} not found.");
            }
            return product;
        }
    }
}
