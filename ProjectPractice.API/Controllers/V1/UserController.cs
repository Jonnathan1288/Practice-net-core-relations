
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;
using System.Collections;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service) {
            _service = service; 
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<ActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpGet]
        [Route("find-by-id/{id:int}")]
        public async Task<ActionResult> findById(int id) => Ok(ResponseHandler.Ok( await _service.FindByIdAsync(id)));

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> save([FromBody] User u) => Ok(ResponseHandler.Ok( await _service.SaveAsync(u)));

        [HttpPost]
        [Route("save-multiple-async")]
        public async Task<ActionResult> saveMultipleAsync(IEnumerable<User> users) 
        {
            return Ok(ResponseHandler.Ok(await _service.SaveAllAsync(users)));
        }
    }
}
