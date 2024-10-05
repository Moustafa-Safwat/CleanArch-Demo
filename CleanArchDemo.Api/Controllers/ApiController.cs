﻿using AutoMapper;
using CleanArchDemo.Core.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Error = CleanArchDemo.Core.Shared.Error;

namespace CleanArchDemo.Api.Controllers
{
    /// <summary>
    /// Base API controller providing common response handling.
    /// </summary>
    [ApiController]
    public class ApiController(ISender sender,IMapper mapper) : ControllerBase
    {
        protected ISender Sender => sender;
        protected IMapper Mapper => mapper;

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

        /// <summary>
        /// Handles the result by wrapping it in a response object and calling the base method.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="value">The value to handle.</param>
        /// <param name="baseMethod">The base method to call.</param>
        /// <param name="statusCode">The status code to use.</param>
        /// <returns>The result wrapped in a response object.</returns>
        private static T HandleResult<T>(object? value, Func<object, T> baseMethod, StatusCode statusCode) where T : ObjectResult
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
