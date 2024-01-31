using Microsoft.AspNetCore.Mvc;

namespace WebApiThreadUsage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("Sync")]
        public IActionResult GetSync() // this method will be called as sync.
        {
            Thread.Sleep(1000);
            return Ok();
        }

        [HttpGet]
        [Route("Async")]
        public async Task<IActionResult> GetAsync() // this remarks that this method will be called as async. It says to the server directly.
        {
            await Task.Delay(1000);
            return Ok();
        }
    }
}
