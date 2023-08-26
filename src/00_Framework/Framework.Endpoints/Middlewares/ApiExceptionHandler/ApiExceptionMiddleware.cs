﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Framework.Endpoints.Middlewares.ApiExceptionHandler;

public class ApiExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiExceptionMiddleware> _logger;
    private readonly ApiExceptionOptions _options;

    public ApiExceptionMiddleware(ApiExceptionOptions options, RequestDelegate next,
        ILogger<ApiExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
        _options = options;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var error = new ApiError
        {
            Id = Guid.NewGuid().ToString(),
            Status = (short)HttpStatusCode.InternalServerError,
            Title = "SOME_KIND_OF_ERROR_OCCURRED_IN_THE_API"
        };

        _options.AddResponseDetails?.Invoke(context, exception, error);

        var innerExMessage = GetInnermostExceptionMessage(exception);

        var level = _options.DetermineLogLevel?.Invoke(exception) ?? LogLevel.Error;
        _logger.Log(level, exception, "BADNESS!!! " + innerExMessage + " -- {ErrorId}.", error.Id);

        var result = JsonConvert.SerializeObject(error);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(result);
    }
    private string GetInnermostExceptionMessage(Exception exception)
    {
        if (exception.InnerException != null)
            return GetInnermostExceptionMessage(exception.InnerException);

        return exception.Message;
    }
}
