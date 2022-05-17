using CinemaPlatform.BLL.Services;
using CinemaPlatform.Common.Dtos.Hall;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Controllers
{
    [Route("api/hall")]
    public class HallController : Controller
    {
        private readonly HallService _hallService;

        public HallController(HallService hallService)
        {
            _hallService = hallService;
        }

        [HttpPost("createHall")]
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
