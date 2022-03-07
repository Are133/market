namespace market.API.Controllers
{
    using market.API.Errors;
    using Microsoft.AspNetCore.Mvc;

    [Route("errors")]
    [ApiController]
    public class ErrorController : BaseAPIController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new CodeErrorResponse(code));
        }
    }
}
