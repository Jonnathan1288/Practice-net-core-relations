using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly ITypeVehicleService _service;
        public VehicleTypeController(ITypeVehicleService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<IActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpPost]
        [Route("save-async")]
        public async Task<ActionResult> saveAsync([FromBody] VehiclesType v) => Ok(ResponseHandler.Ok(await _service.SaveAsync(v)));

        [HttpPost]
        [Route("save")]
        public ActionResult Save([FromBody] VehiclesType t) => Ok(ResponseHandler.Ok(_service.Save(t)));

        [HttpGet]
        [Route("find-by-name/{name}")]
        public ActionResult FindByNameTypeVehicle(string name) => Ok(ResponseHandler.Ok(_service.FindByNameTypeVehicle(name)));

    }
}
