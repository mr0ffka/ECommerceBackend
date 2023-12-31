﻿
using ECommerce.Api.Models;
using ECommerce.Application.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Mime;

namespace ECommerce.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
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


        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            _logger.LogError(ex, $"Something Went wrong while processing {context.Request.Path}");
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            CustomValidationProblemDetails error = ex switch
            {
                ValidationException validationException => HandleValidationException(validationException, ref statusCode),
                BadRequestException badRequestException => HandleBadRequestException(badRequestException, ref statusCode),
                NotFoundException notFoundException => HandleResourceNotFoundException(notFoundException, ref statusCode),
                UnauthorizedException unauthorizedException => HandleUnauthorizedException(unauthorizedException, ref statusCode),
                _ => HandleUnhandledExceptions(ex, ref statusCode)
            };

            if (!context.Response.HasStarted)
            {
                context.Response.Clear();
                context.Response.ContentType = MediaTypeNames.Application.Json;
                context.Response.StatusCode = (int)statusCode;
                await context.Response.WriteAsJsonAsync(error);
            }
        }

        private CustomValidationProblemDetails HandleUnhandledExceptions(Exception ex, ref HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.InternalServerError;
            var error = new CustomValidationProblemDetails
            {
                Title = "An unhandled error occurred while processing this request",
                Status = (int)statusCode,
                Type = nameof(Exception),
                Detail = ex.InnerException?.Message
            };

            return error;
        }

        private CustomValidationProblemDetails HandleUnauthorizedException(UnauthorizedException unauthorizedException, ref HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.Unauthorized;
            var error = new CustomValidationProblemDetails
            {
                Title = unauthorizedException.Message,
                Status = (int)statusCode,
                Type = nameof(UnauthorizedException),
                Detail = unauthorizedException.InnerException?.Message
            };

            return error;
        }

        private CustomValidationProblemDetails HandleResourceNotFoundException(NotFoundException notFoundException, ref HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.NotFound;
            var error = new CustomValidationProblemDetails
            {
                Title = notFoundException.Message,
                Status = (int)statusCode,
                Type = nameof(NotFoundException),
                Detail = notFoundException.InnerException?.Message
            };

            return error;
        }

        private CustomValidationProblemDetails HandleBadRequestException(BadRequestException badRequestException, ref HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.BadRequest;
            var error = new CustomValidationProblemDetails
            {
                Title = badRequestException.Message,
                Status = (int)statusCode,
                Detail = badRequestException.InnerException?.Message,
                Type = nameof(BadRequestException),
                Errors = badRequestException.Errors
            };

            return error;
        }

        private CustomValidationProblemDetails HandleValidationException(ValidationException validationException, ref HttpStatusCode statusCode)
        {
            statusCode = HttpStatusCode.BadRequest;
            var error = new CustomValidationProblemDetails
            {
                Title = validationException.Message,
                Status = (int)statusCode,
                Detail = validationException.InnerException?.Message,
                Type = nameof(ValidationException),
                Errors = validationException.Errors
                    .GroupBy(x => x.PropertyName)
                    .ToDictionary(
                        g => g.Key,
                        g => g.Select(x => x.ErrorMessage).ToArray()
                    )
            };

            return error;
        }
    }
}
