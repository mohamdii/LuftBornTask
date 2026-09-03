using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LuftBornTask.Application.Validations
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T entity);
    }
}
