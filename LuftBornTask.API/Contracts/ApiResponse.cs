namespace LuftBornTask.API.Contracts
{
    public class ApiResponse<T>
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
        public T? Data { get; init; }
        public IReadOnlyCollection<string>? Errors { get; init; }

        public static ApiResponse<T> SuccessResponse(T data, string? message = null) =>
            new()
            {
                Success = true,
                Data = data,
                Message = message
            };

        public static ApiResponse<T> FailureResponse(string message, IReadOnlyCollection<string>? errors = null) =>
            new()
            {
                Success = false,
                Message = message,
                Errors = errors
            };
    }
}
