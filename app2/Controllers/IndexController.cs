using Microsoft.AspNetCore.Mvc;

namespace app2.Controllers
{
    [ApiController]
    [Route("/")]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Hello from app2";
    }
}
