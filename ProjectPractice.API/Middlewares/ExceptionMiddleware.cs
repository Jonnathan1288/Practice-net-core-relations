using Microsoft.EntityFrameworkCore;
using Npgsql;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Exceptions.BadRequest;
using ProjectPractice.Domain.Interfaces.Services.Custom;
using System.Net;
using System.Text.Json;

namespace ProjectPractice.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILoggerManager _logger;
        private readonly RequestDelegate _requestDelegate;

        public ExceptionMiddleware(ILoggerManager logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "application/json";
                    if (context.Response.StatusCode == 404)
                    {
                        await context.Response.WriteAsync(JsonSerializer.Serialize(ResponseHandler.NotFound()));
                    }
                }
            }
            catch (AccessViolationException e)
            {
                _logger.LogError($"");
                await HandleExceptionAsync(context, e);
            }
            catch (NotImplementedException e)
            {
                _logger.LogWarning($"Not implemented exception: {e}");
                await HandleExceptionAsync(context, e);
            }
            catch (DbUpdateException e)
            {
                _logger.LogError($"Database Update Exception: {e}");
                await HandleExceptionAsync(context, e.GetBaseException());
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                await HandleExceptionAsync(context, e);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Dictionary<string, object> exceptionProperties = exception switch
            {
                PostgresException => PostgresExceptionData((PostgresException)exception),
                BadRequestException => BadRequestExceptionData((BadRequestException)exception),
                _ => ResponseHandler.Error(500, exception.Message),
            };
            ;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exceptionProperties["statusCode"];
            await context.Response.WriteAsync(JsonSerializer.Serialize(exceptionProperties));
        }

        private static Dictionary<string, object> PostgresExceptionData(PostgresException exception)
        {
            return exception.SqlState switch
            {
                "22001" => ResponseHandler.Conflict($"data-is-too-long-or-too-small"),
                "23503" => ResponseHandler.Conflict($"foreign-key-do-not-exist-{exception.ConstraintName}"),
                "23505" => ResponseHandler.Conflict($"duplicate-unique-constraint-{exception.ConstraintName}"),
                _ => ResponseHandler.Error((int)HttpStatusCode.InternalServerError, exception.Message),
            };
        }


        private static Dictionary<string, object> BadRequestExceptionData(BadRequestException exception)
        {
            return exception switch
            {
                _ => ResponseHandler.BadRequest(exception.Code),
            };
        }
    }
}
