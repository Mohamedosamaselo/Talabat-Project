using LinkDev.Talabat.Api.Controllers.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Api.Controllers.Common
{
    [   ApiController]
    [Route("Errors/{Code}")]
    [ApiExplorerSettings(IgnoreApi =false)]
    public class ErrorsControllers:ControllerBase
    {

        [HttpGet]
        public IActionResult Error(int Code)
        {

           if (Code == (int)HttpStatusCode.NotFound)
           {
               var response = new ApiResponse((int)HttpStatusCode.NotFound, $"the Requested EndPoint: {HttpContext.Request.Path} is not Found");
               return NotFound(response);
           };
            return StatusCode(Code);
        }
    }
}
