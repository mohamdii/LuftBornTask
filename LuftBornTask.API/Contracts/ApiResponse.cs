using System.Net;

namespace LuftBornTask.API.Contracts;

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResponse<T> Ok(T data) => new ApiResponse<T>
    {
        StatusCode = HttpStatusCode.OK,
        Data = data
    };

    public static ApiResponse<T> BadRequest(string message) => new ApiResponse<T>
    {
        StatusCode = HttpStatusCode.BadRequest,
        ErrorMessage = message
    };

    public static ApiResponse<T> NotFound(string message) => new ApiResponse<T>
    {
        StatusCode = HttpStatusCode.NotFound,
        ErrorMessage = message
    };

    public static ApiResponse<T> Unauthorized(string message = "Unauthorized") => new ApiResponse<T>
    {
        StatusCode = HttpStatusCode.Unauthorized,
        ErrorMessage = message
    };

    public static ApiResponse<T> Forbidden(string message = "Forbidden") => new ApiResponse<T>
    {
        StatusCode = HttpStatusCode.Forbidden,
        ErrorMessage = message
    };

    public static ApiResponse<T> Error(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        => new ApiResponse<T>
        {
            StatusCode = statusCode,
            ErrorMessage = message
        };
}

public class ApiResponse
{

    public ApiResponse() { }



    public HttpStatusCode StatusCode { get; set; }

    public bool IsSuccess
    {
        get
        {
            switch (StatusCode)
            {
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                case HttpStatusCode.NonAuthoritativeInformation:
                case HttpStatusCode.NoContent:
                case HttpStatusCode.ResetContent:
                case HttpStatusCode.PartialContent:
                case HttpStatusCode.MultiStatus:
                case HttpStatusCode.AlreadyReported:
                case HttpStatusCode.IMUsed:
                    return true;

                default:
                    return false;
            }
        }
    }

    public string? ErrorMessage { get; set; }

    public static ApiResponse Ok(string message) => new ApiResponse
    {
        StatusCode = HttpStatusCode.OK,
        ErrorMessage = message
    };

    public static ApiResponse BadRequest(string message) => new ApiResponse
    {
        StatusCode = HttpStatusCode.BadRequest,
        ErrorMessage = message
    };
    public static ApiResponse NotFound(string message) => new ApiResponse
    {
        StatusCode = HttpStatusCode.NotFound,
        ErrorMessage = message
    };
    public static ApiResponse Unauthorized(string message = "Unauthorized") => new ApiResponse
    {
        StatusCode = HttpStatusCode.Unauthorized,
        ErrorMessage = message
    };
    public static ApiResponse Forbidden(string message = "Forbidden") => new ApiResponse
    {
        StatusCode = HttpStatusCode.Forbidden,
        ErrorMessage = message
    };
}
