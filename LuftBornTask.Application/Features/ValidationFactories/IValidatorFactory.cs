using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Features.ValidationFactories
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
    }
}
