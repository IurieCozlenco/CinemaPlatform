using CinemaPlatform.BLL.Services;
using CinemaPlatform.Common.Dtos.Hall;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Controllers
{
    [Route("api/hall")]
    [ApiController]
    public class HallController : ControllerBase
    {
        private readonly HallService _hallService;

        public HallController(HallService hallService)
        {
            _hallService = hallService;
        }

        [HttpPost("createHall")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateHall([FromBody] HallCreateDTO hallCreateDTO)
        {
            var result = await _hallService.CreateHallAsync(hallCreateDTO);

            return result ? Ok() : BadRequest();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetHalls()
        {
            return Ok(await _hallService.GetAll());
        }
    }
}
