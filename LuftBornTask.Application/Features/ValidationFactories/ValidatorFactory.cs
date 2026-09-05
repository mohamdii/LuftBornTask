using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.ValidationFactories
{
    public class ValidatorFactory : IValidatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ValidatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IValidator<T> GetValidator<T>()
        {
            var validator = _serviceProvider
                .GetService<IValidator<T>>();

            if (validator == null)
            {
                throw new InvalidOperationException(
                    $"No validator found for {typeof(T).Name}");
            }

            return validator;
        }
    }
}
