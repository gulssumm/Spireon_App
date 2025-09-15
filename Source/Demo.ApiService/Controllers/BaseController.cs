using Microsoft.AspNetCore.Mvc;

namespace Demo.ApiService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected ActionResult HandleResult<T>(T result) where T : class
        {
            if (result == null) return NotFound();
            return Ok(result);
        }
        protected ActionResult HandleResult<T>(List<T> result) where T : class
        {
            if (result == null || !result.Any())
                return NotFound("No records found");
            return Ok(result);
        }

        protected ActionResult HandleException(Exception ex)
        {
            // Log the exception
            // TODO: ILogger can be injected for better logging
            return StatusCode(500, new { message = "An error occurred", details = ex.Message });
        }

        protected ActionResult ValidateModel()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok();
        }
    }
}
