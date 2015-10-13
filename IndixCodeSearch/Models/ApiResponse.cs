using Indix.Constants;

namespace Indix.Models
{
    /// <summary>
    /// WebApi response
    /// </summary>
    public class ApiResponse
    {
        public bool Status { get; set; }
        public object Payload { get; set; }

        public static ApiResponse CreateSuccessResponse<T>(T result)
        {
            return new ApiResponse
            {
                Status = true,
                Payload = result
            };
        }

        public static ApiResponse CreateErrorResponse(ApiErrorCodes errorCode, string errorMessage)
        {
            return new ApiResponse
            {
                Status = false,
                Payload = ApiError.CreateApiError(errorCode, errorMessage)
            };
        }
    }
}
