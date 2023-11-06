using EFCommonCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleStatusController : ControllerBase
    {
        private readonly IVehicleStatusService _service;

        public VehicleStatusController(IVehicleStatusService service) { 
            _service = service;
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<IActionResult> findALLAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpPost]
        [Route("save-async")]
        public async Task<ActionResult> saveAsync([FromBody] VehicleStatus vs) => Ok(ResponseHandler.Ok(await _service.SaveAsync(vs)));



    }
}
