using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            return _unitOfWork.Repository<Product>().AddAsync(dto);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, UpdateProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
