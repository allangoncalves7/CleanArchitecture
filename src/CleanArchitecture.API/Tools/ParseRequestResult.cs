using CleanArchitecture.Application.Results;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CleanArchitecture.API.Tools
{
    public class ParseRequestResult : ControllerBase
    {
        public ActionResult ParseToActionResult(Result result)
        {
            switch (result.ResultCode)
            {
                case (int)HttpStatusCode.OK:
                    return Ok(result);
                case (int)HttpStatusCode.BadRequest:
                    return BadRequest(result);
                case (int)HttpStatusCode.NotFound:
                    return NotFound(result);
                default:
                    return BadRequest(result);
            }
        }
    }
}
