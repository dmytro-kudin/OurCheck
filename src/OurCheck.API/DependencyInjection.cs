using Asp.Versioning;
using OurCheck.API.Exceptions;

namespace OurCheck.API;

public static class DependencyInjection
{
    public static void AddApiServices(this IHostApplicationBuilder builder)
    {
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();
        
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true; // Adds api-supported-versions header
                // Use URL segment (v{version}) or Headers/Query String
                options.ApiVersionReader = ApiVersionReader.Combine(
                    new UrlSegmentApiVersionReader(),
                    new HeaderApiVersionReader("x-api-version")
                );
            })
            .AddApiExplorer(options =>
            {
                // Required for Swagger/OpenAPI
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
        
    }
}