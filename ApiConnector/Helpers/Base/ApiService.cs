using ApiConnector.Helpers.Errors;
using System.Net;

namespace ApiConnector.Helpers.Base;

public abstract class ApiService
{
    public ApiResult<T> BuildApiResult<T>(HttpStatusCode statusCode, string error)
    {
        return statusCode switch
        {
            HttpStatusCode.BadRequest => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.Unauthorized => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.NotFound => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.TooManyRequests => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.InternalServerError => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.ServiceUnavailable => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            HttpStatusCode.GatewayTimeout => ApiResult.Failure<T>(new ApiError(statusCode.ToString(), error)),
            _ => ApiResult.Failure<T>(new ApiError($"Unknown Error with statuscode {statusCode}", error))
        };
    }
}
