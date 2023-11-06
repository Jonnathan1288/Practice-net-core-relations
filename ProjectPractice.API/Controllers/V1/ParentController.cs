using EFCommonCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _service;
        public ParentController(IParentService service) { 
            _service = service;
        }

        [HttpGet]
        [Route("find-all")]
        public ActionResult findAll() => Ok(ResponseHandler.Ok( _service.FindAll()));

        [HttpGet]
        [Route("find-all-async")]
        public async Task<ActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpGet]
        [Route("find-by-id/{id:int}")]
        public async Task<ActionResult> findByIdAsync(int id) => Ok(ResponseHandler.Ok( await _service.FindByOne(id)));

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> saveAsync([FromBody] Parent p) => Ok(ResponseHandler.Ok(await _service.SaveAsync(p)));

        [HttpGet]
        [Route("find-all-pageable-async")]
        public async Task<ActionResult> findAllPageableAsync([FromQuery] int? page, [FromQuery] int? size) {
            return Ok(ResponseHandler.Ok(await _service.FindAllPageableAsync(PageRequest.Of((page ?? 1) - 1, size ?? 2))));
        }
        
    }
}
