using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.ValidationFactories
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
    }
}
