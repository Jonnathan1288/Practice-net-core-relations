using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectPractice.API.DTOs;
using ProjectPractice.API.Handlers;
using ProjectPractice.API.Mappers;
using ProjectPractice.Domain.Entities.Public;
using ProjectPractice.Domain.Interfaces.Services.Public;

namespace ProjectPractice.API.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _service;

        public BrandController(IBrandService service) {
            _service = service;
        }

        [HttpGet]
        [Route("find-all-async")]
        public async Task<ActionResult> findAllAsync() => Ok(ResponseHandler.Ok(await _service.FindAllAsync()));

        [HttpPost]
        [Route("save-async")]
        public async Task<ActionResult> saveAsync([FromBody] Brand b) => Ok(ResponseHandler.Ok(await _service.SaveAsync(b)));

        [HttpPost]
        [Route("save-all-transactional")]
        public async Task<ActionResult> SaveTransactional([FromBody] List<Brand> b) {
            return Ok(ResponseHandler.Ok(await _service.SaveAllTransactional(b)));
        }

        [HttpGet]
        [Route("exist-by-brand-name/{brand_name}")]
        public ActionResult<bool> ExistByBrandName(string brand_name) => Ok(ResponseHandler.Ok(_service.ExistBrandName(brand_name.Trim())));

        [HttpPost]
        [Route("save-all-async")]
        public async Task<ActionResult> SaveAllAsync([FromBody] List<Brand> brands) 
        {
            return Ok(ResponseHandler.Ok(await _service.SaveAllAsync(brands)));
        }

        [HttpPost]
        [Route("save-dto")]
        public async Task<ActionResult> SaveAsyncDTO([FromBody] BrandDTO d) 
        {
            return Ok(ResponseHandler.Ok(await _service.SaveAsync(DTOToEntity.BrandFromBrandDTO(d))));
        }

        [HttpPost]
        [Route("save-dto-list")]
        public async Task<ActionResult> SaveAllAsyncDTO([FromBody] BrandListDTO b) 
        {
            return Ok(ResponseHandler.Ok(await _service.SaveAllAsync(DTOToEntity.BrandFromBrandListDTO(b))));
        }
    }
}
