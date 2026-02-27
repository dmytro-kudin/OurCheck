using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace OurCheck.Application.Common.Behaviors;

public class RequestResponseLoggingBehavior<TRequest, TResponse>(ILogger<RequestResponseLoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var correlationId = Guid.NewGuid();

        // Request Logging
        var requestJson = JsonSerializer.Serialize(request);
        logger.LogInformation("Handling request {CorrelationID}: {Request}", correlationId, requestJson);

        var response = await next();
        
        // Response logging
        var responseJson = JsonSerializer.Serialize(response);
        logger.LogInformation("Response for {Correlation}: {Response}", correlationId, responseJson);

        // Return response
        return response;
    }
}