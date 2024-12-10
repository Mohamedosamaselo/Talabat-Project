using LinkDev.Talabat.Core.Application.Abstraction.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace LinkDev.Talabat.Api.Services
{
    public class LoggedInUserServices : ILoggedInUserService
    {
        private readonly IHttpContextAccessor?  _httpContextAccessor;

        public string? UserId {  get; }

        public LoggedInUserServices(IHttpContextAccessor? httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        
             UserId = _httpContextAccessor?.HttpContext?.User.FindFirstValue(ClaimTypes.PrimarySid);
        }



    }
}
