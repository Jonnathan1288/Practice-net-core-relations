using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string path() {
            return  "hola como estas 😁";
        }
    }
}
