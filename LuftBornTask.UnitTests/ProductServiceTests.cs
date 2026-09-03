using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using LuftBornTask.Application.DTOs;
using LuftBornTask.Application.Interfaces;
using LuftBornTask.Application.Services;
using LuftBornTask.Domain.Entities;
using Moq;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Text;
namespace LuftBornTask.UnitTests
{
    public class ProductServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly Mock<IRepository<Product>> _repositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductService _sut;
        private readonly Mock<LuftBornTask.Application.ValidationFactories.IValidatorFactory> _validatorFactoryMock;

        public ProductServiceTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _repositoryMock = new Mock<IRepository<Product>>();
            _mapperMock = new Mock<IMapper>();
            _validatorFactoryMock = new Mock<LuftBornTask.Application.ValidationFactories.IValidatorFactory>();

            _unitOfWorkMock
                .Setup(u => u.Repository<Product>())
                .Returns(_repositoryMock.Object);

            _sut = new ProductService(_unitOfWorkMock.Object, _mapperMock.Object, _validatorFactoryMock.Object);
        }

        private void SetupValidatorToPass<T>()
        {
            var validatorMock = new Mock<IValidator<T>>();
            validatorMock
                .Setup(v => v.ValidateAsync(It.IsAny<T>(), default)).ReturnsAsync(new ValidationResult());

            _validatorFactoryMock
              .Setup(f => f.GetValidator<T>())
                 .Returns(validatorMock.Object);

        }

        private void SetupValidatorToFail<T>(params string[] errorMessages)
        {
            var failures = errorMessages.Select(m => new ValidationFailure("Property", m)).ToList();

            var validatorMock = new Mock<IValidator<T>>();
            validatorMock
                .Setup(v => v.ValidateAsync(It.IsAny<T>(), default))
                .ReturnsAsync(new ValidationResult(failures));

            _validatorFactoryMock
                .Setup(f => f.GetValidator<T>())
                .Returns(validatorMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_WhenProductDoesNotExist_ReturnsNull()
        {
            // Arrange
            _repositoryMock
                .Setup(r => r.GetByIdAsync(1000))
                .ReturnsAsync((Product?)null);

            // Act
            var result = await _sut.GetByIdAsync(1);

            // Assert
            Assert.Null(result);
        }
        [Fact]
        public async Task GetByIdAsync_WhenProductExists_ReturnsMappedDto()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Widget" };
            var expectedDto = new ProductDto { Id = 1, Name = "Widget" };

            _repositoryMock
                .Setup(r => r.GetByIdAsync(1))
                .ReturnsAsync(product);

            _mapperMock
                .Setup(m => m.Map<ProductDto>(product))
                .Returns(expectedDto);

            // Act
            var result = await _sut.GetByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.Id, result!.Id);
            Assert.Equal(expectedDto.Name, result.Name);
        }
        [Fact]
        public async Task UpdateAsync_WhenProductDoesNotExist_ThrowsNotFoundException()
        {
            // Arrange
            var dto = new UpdateProductDto { Name = "Widget", Price = 10 };
            SetupValidatorToPass<UpdateProductDto>();

            _repositoryMock
                .Setup(r => r.GetByIdAsync(99))
                .ReturnsAsync((Product?)null);

            // Act
            var act = () => _sut.UpdateAsync(99, dto);

            // Assert
            await Assert.ThrowsAsync<Exception>(act);
            _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never);
        }
    }
}
