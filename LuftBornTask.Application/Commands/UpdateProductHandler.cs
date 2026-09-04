using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, ProductDto>
    {
        private readonly IProductService _productService;

        public UpdateProductHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ProductDto> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _productService.UpdateAsync(request.Id, request.Dto) ?? throw new InvalidOperationException("Failed to update product");
            return updatedProduct;
        }
    }
}
