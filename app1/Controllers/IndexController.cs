using Microsoft.AspNetCore.Mvc;

namespace app1.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello from app1";
    }
}
