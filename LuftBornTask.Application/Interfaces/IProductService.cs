using LuftBornTask.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto?> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task UpdateAsync(int id, UpdateProductDto dto);
        Task DeleteAsync(int id);
    }
}
