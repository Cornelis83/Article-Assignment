using System;
using Common.CustomExceptions;

namespace WebApi.BaseClasses
{
    public abstract class BaseController<TLogic>(TLogic logic) : ControllerBase
    {
        protected readonly TLogic Logic = logic;

        protected IActionResult GuardedExecute<T>(Func<T> function)
        {
            try
            {
                var result = function();
                return new OkObjectResult(result);
            }
            catch (ExceptionWithMessages exception)
            {
                return BadRequest(exception.Messages);
            }
            catch             
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    "An unhandled error has occured. Contact the provider of the API to report this issue. " +
                    "Please provide the called endpoint and the input data when reporting the issue.");
            }
        }
    }
}
