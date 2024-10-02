using CleanArchDemo.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Error = CleanArchDemo.Core.Shared.Error;

namespace CleanArchDemo.Api.Controllers
{
    [ApiController]
    public class ApiController(ISender sender) : ControllerBase
    {
        protected ISender Sender => sender;

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            return HandleResult(value, base.Ok, Core.Shared.StatusCode.Ok);
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
        {
            return HandleResult(error, base.BadRequest, Core.Shared.StatusCode.BadRequest);
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
        {
            return HandleResult(value, base.NotFound, Core.Shared.StatusCode.NotFound);
        }

        private static T HandleResult<T>(object? value, Func<object, T> baseMethod, Core.Shared.StatusCode statusCode) where T : ObjectResult
        {
            if (value == null)
            {
                return baseMethod(Response<object>.Create(Result.Failure(Error.NullValue), statusCode));
            }

            var type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = type.GetGenericArguments()[0];
                var responseType = typeof(Response<>).MakeGenericType(resultType);
                var createMethod = responseType.GetMethod("Create", [type, typeof(StatusCode)]);

                if (createMethod != null)
                {
                    var responseObject = createMethod.Invoke(null, [value, statusCode]);
                    if (responseObject != null)
                    {
                        return baseMethod(responseObject);
                    }
                }
            }

            // If the value is not of type Result<T>, wrap it in a Response<object>
            var resultInstance = Response<object>.Create(value, statusCode);
            return baseMethod(resultInstance);
        }
    }
}
