using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyCollection<string> Errors { get; set; }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : base("One or more validation failures have occurred.")
        {
            Errors = failures.Select(e => e.ErrorMessage).ToList();
        }
    }
}
