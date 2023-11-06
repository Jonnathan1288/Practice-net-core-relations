using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillService _service;
        public BillController(IBillService service) 
        {
            _service = service; 
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<ActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpPost]
        [Route("save-async")]
        public async Task<ActionResult> saveAsync([FromBody] Bill b) => Ok(ResponseHandler.Ok(await _service.SaveAsync(b)));
    }
}
