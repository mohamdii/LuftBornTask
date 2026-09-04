using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace LuftBornTask.Application.Behavior
{
    public class LoggingBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehaviors<TRequest, TResponse>> _logger;

        public LoggingBehaviors(ILogger<LoggingBehaviors<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling {RequestName} with content: {@Request}", typeof(TRequest).Name, request);
            var response = await next();
            _logger.LogInformation("Response for {RequestName}: {@Response}", typeof(TRequest).Name, response);
            return response;
        }
    }
}
