using EFCommonCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.Handlers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;
using ProjectPractice.Domain.Parametrized;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;
        public VehicleController(IVehicleService service) {
            _service = service;
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<IActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindALlAsync()));

        [HttpGet]
        [Route("find-by-id/{id:int}")]
        public async Task<ActionResult> findByIdAsync(int id) => Ok(ResponseHandler.Ok(await _service.FindByIdAsync(id)));

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> saveAsync([FromBody] Vehicle v) => Ok(ResponseHandler.Ok(await _service.SaveAsync(v)));

        [HttpGet]
        [Route("find-all-pageable-async")]
        public async Task<ActionResult> findAllPagebleAsync([FromQuery] int? page, [FromQuery] int? size) {
            return Ok(ResponseHandler.Ok(await _service.FindAllPageableAsync(PageRequest.Of((page ?? 1) - 1, size ?? 5))));
        }

        [HttpPut]
        [Route("update-async")]
        public async Task<ActionResult> UpdateAsync([FromBody] Vehicle v) {
            return Ok(ResponseHandler.Ok(await _service.UpdateAsync(v)));
        }

        [HttpGet]
        [Route("find-all-by-brand-name-async/{brandname}")]
        public async Task<ActionResult> findAllByBrandNameAsync(string brandname) {
            return Ok(ResponseHandler.Ok(await _service.FindByBrand(brandname)));
        }

        [HttpGet]
        [Route("find-by-filter-information")]
        public async Task<ActionResult> FindAllByFilter() => Ok(ResponseHandler.Ok(await _service.FindAllByFilter()));

        [HttpGet]
        [Route("find-all-information-query/{brand_name}")]
        public ActionResult FindAllFromSql(string brand_name) => Ok(ResponseHandler.Ok(_service.FindAllFromSql(brand_name)));

        [HttpGet]
        [Route("find-all-by-multiple-params")]
        public ActionResult FindAllWithMultipleParams([FromQuery] VehicleParams? vehicleParams )
        {
            return Ok(ResponseHandler.Ok(_service.FindAllWithMultipleParams(vehicleParams)));
        }
    }

}
