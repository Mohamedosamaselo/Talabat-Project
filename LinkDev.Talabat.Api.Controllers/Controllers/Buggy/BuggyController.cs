using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Api.Controllers.Errors;
using Microsoft.AspNetCore.Mvc;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Buggy
{
    internal class BuggyController : BaseApiController
    {
        [HttpGet("notfound")] // Get : api/buggy/notFound
        public IActionResult GetNotFoundRequest()
        {
            throw new NotFoundException();
            return NotFound(new ApiResponse(404));
        }

        [HttpGet("badRequest")] // Get : api/buggy/badRequest
        public IActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("unauthorized")] // Get : api/buggy/unauthorized
        public IActionResult GetUnautorizedErro()
        {
            return Unauthorized(new ApiResponse(401));
        }

    }

}
