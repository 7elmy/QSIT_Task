using Microsoft.AspNetCore.Mvc;
using QSIT_Task_2.Contracts.Requests;
using QSIT_Task_2.Interfaces;

namespace QSIT_Task_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapController(IMapService mapService)
        {
            _mapService = mapService;
        }


        [HttpGet("map-configurations")]
        public IActionResult GetMapConfigurations()
        {
            var response = _mapService.GetMapConfigurations();
            return Ok(response);

        }

        [HttpPost("map-configurations")]
        public IActionResult SaveMapConfigurations(SaveMapConfigurationsRequest requestModel)
        {
            var response = _mapService.SaveMapConfigurations(requestModel);
            if (response.IsSuccess)
                return Ok();
            return BadRequest(response);
        }

        [HttpGet("map-types")]
        public IActionResult GetParentMapTypes()
        {
            var mapTypes = _mapService.GetParentMapTypes();
            return Ok(mapTypes.MapTypes);
        }

        [HttpGet("map-sub-types")]
        public IActionResult GetMapSubTypes([FromQuery] int parentId)
        {
            var mapSubTypes = _mapService.GetMapSubTypes(parentId);
            return Ok(mapSubTypes.MapTypes);
        }
    }
}
