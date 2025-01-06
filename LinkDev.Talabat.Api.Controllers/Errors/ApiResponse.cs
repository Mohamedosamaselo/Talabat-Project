namespace LinkDev.Talabat.Api.Controllers.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        public ApiResponse(int statusCode, string? message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultCodeForStatusCode(statusCode);
        }

        private string? GetDefaultCodeForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request You have Made",
                401 => "Unauthorized",
                404 => "Resources wasnot Found",
                500 => "Error leads t dark side",
                _ => null
            };
        }
    }
}
