
using Indix.Constants;

namespace Indix.Models
{
    public class ApiError
    {
        public ApiErrorCodes ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public static ApiError CreateApiError(ApiErrorCodes errorCode, string errorMessage)
        {
            return new ApiError
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage
            };
        }
    }
}
