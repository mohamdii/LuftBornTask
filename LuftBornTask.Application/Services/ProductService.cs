using AutoMapper;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Application.ValidationFactories;
using LuftBornTask.Application.Validations;
using LuftBornTask.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace LuftBornTask.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidatorFactory _validatorFactory;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IValidatorFactory validatorFactory)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validatorFactory = validatorFactory;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = _mapper.Map<Product>(dto);

            await ValidateAsync(dto);

            await _unitOfWork.Repository<Product>().AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto?> DeleteAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (product == null) return null;

            _unitOfWork.Repository<Product>().Delete(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _unitOfWork.Repository<Product>().GetAllAsync();
            IEnumerable<ProductDto> productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);
            return productDtos ?? Enumerable.Empty<ProductDto>();
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            return product == null ? null : _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);
            if (product == null) return null;

            _mapper.Map(dto, product);
            _unitOfWork.Repository<Product>().Update(product);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<ProductDto>(product);
        }

        #region Private Methods
        private async Task ValidateAsync<T>(T dto)
        {
            var validator = _validatorFactory.GetValidator<T>();
            var result = await validator.ValidateAsync(dto);

            if (!result.IsValid)
            {
                throw new ValidationException(
        string.Join(", ", result.Errors));
            }
        }
        #endregion
    }
}