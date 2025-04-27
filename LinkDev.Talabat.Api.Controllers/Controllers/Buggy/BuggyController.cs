using LinkDev.Talabat.Api.Controllers.Base;
using LinkDev.Talabat.Api.Controllers.Errors;
using LinkDev.Talabat.Api.Controllers.Exceptions;
using LinkDev.Talabat.Core.Application.Abstraction.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LinkDev.Talabat.Api.Controllers.Controllers.Buggy
{
    public class BuggyController : BaseApiController
    {
        [HttpGet("notfound")] // Get : api/buggy/notFound
        public IActionResult GetNotFoundRequest()
        {
            throw new NotFoundException();
            //return NotFound(new ApiResponse(404));
        }

        [HttpGet("servererror")] // Get : api/buggy/servererror
        public IActionResult GetServerError()
        {
            throw new Exception();// 500
        }

        [HttpGet("badRequest")] // Get : api/buggy/badRequest
        public IActionResult GetBadRequest()
        {

            return BadRequest(new ApiResponse(400));
        }

        [HttpGet("badRequest/{id}")] // Get : api/buggy/badRequest/five
        public IActionResult GetValidationError(int id)// 400
        {

            return Ok();
        }


        [HttpGet("unauthorized")] // Get : api/buggy/unauthorized
        public IActionResult GetUnautorizedErro()
        {
            return Unauthorized(new ApiResponse(401));
        }

    }

}
