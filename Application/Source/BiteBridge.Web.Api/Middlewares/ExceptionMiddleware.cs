using BiteBridge.Common.Interfaces;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using BiteBridge.Web.Api.Objects;
using BiteBridge.Application.Exceptions;

namespace BiteBridge.Web.Api.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;

	public ExceptionMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IExceptionLogger logger)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex, logger);
		}

		if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
		{
			await HandleUnauthorizedAsync(context);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception ex, IExceptionLogger logger)
	{
		logger.LogException(ex);
		context.Response.ContentType = "application/json";
		context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

		object response;

		if (ex is FluentValidationException validationException)
		{
			context.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;

			response = new ValidationExceptionResponse
			{
				Message = validationException.Message,
				Error = validationException.Failures.ToDictionary(
					_ => _.Key,
					_ => _.Value)
			};
		}
		else
		{
			response = new ExceptionResponse
			{
				Message = ex.Message,
			};
		}

		var settings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			Formatting = Formatting.Indented,
		};
		var json = JsonConvert.SerializeObject(response, settings);

		return context.Response.WriteAsync(json);
	}

	private static Task HandleUnauthorizedAsync(HttpContext context)
	{
		var response = new UnauthorizedAccessException();

		var settings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			Formatting = Formatting.Indented,
		};

		var json = JsonConvert.SerializeObject(response, settings);

		return context.Response.WriteAsync(json);
	}
}