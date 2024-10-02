using CleanArchDemo.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Error = CleanArchDemo.Core.Shared.Error;

namespace CleanArchDemo.Api.Controllers
{
    [ApiController]
    public class ApiController(ISender sender) : ControllerBase
    {
        protected ISender Sender => sender;

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            if (value == null)
            {
                return base.Ok(Response<object>.Create(Result.Failure(Error.NullValue), Core.Shared.StatusCode.Ok));
            }

            var type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = type.GetGenericArguments()[0];
                var responseType = typeof(Response<>).MakeGenericType(resultType);
                var createMethod = responseType.GetMethod("Create", [type, typeof(StatusCode)]);

                if (createMethod != null)
                {
                    var responseObject = createMethod.Invoke(null, [value, Core.Shared.StatusCode.Ok]);
                    return base.Ok(responseObject);
                }
            }

            // If the value is not of type Result<T>, wrap it in a Response<object>
            var resultInstance = Response<object>.Create(value, Core.Shared.StatusCode.Ok);

            return base.Ok(resultInstance);
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
        {

            if (error == null)
            {
                return base.BadRequest(Response<object>.Create(Result.Failure(Error.NullValue), Core.Shared.StatusCode.BadRequest));
            }

            var type = error.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = type.GetGenericArguments()[0];
                var responseType = typeof(Response<>).MakeGenericType(resultType);
                var createMethod = responseType.GetMethod("Create", [type, typeof(StatusCode)]);

                if (createMethod != null)
                {
                    var responseObject = createMethod.Invoke(null, [error, Core.Shared.StatusCode.BadRequest]);
                    return base.BadRequest(responseObject);
                }
            }

            // If the value is not of type Result<T>, wrap it in a Response<object>
            var resultInstance = Response<object>.Create(error, Core.Shared.StatusCode.BadRequest);

            return base.BadRequest(resultInstance);
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
        {
            if (value == null)
            {
                return base.NotFound(Response<object>.Create(Result.Failure(Error.NullValue), Core.Shared.StatusCode.NotFound));
            }

            var type = value.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = type.GetGenericArguments()[0];
                var responseType = typeof(Response<>).MakeGenericType(resultType);
                var createMethod = responseType.GetMethod("Create", [type, typeof(StatusCode)]);

                if (createMethod != null)
                {
                    var responseObject = createMethod.Invoke(null, [value, Core.Shared.StatusCode.NotFound]);
                    return base.NotFound(responseObject);
                }
            }

            // If the value is not of type Result<T>, wrap it in a Response<object>
            var resultInstance = Response<object>.Create(value, Core.Shared.StatusCode.NotFound);

            return base.NotFound(resultInstance);
        }

    }
}
