using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Validations
{
    public interface IValidatorFactory
    {
        IValidator<T> GetValidator<T>();
    }
}
