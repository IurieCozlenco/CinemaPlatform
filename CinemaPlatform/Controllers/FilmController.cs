using CinemaPlatform.BLL.Services;
using CinemaPlatform.Common.Dtos.Film;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Controllers
{
    [Route("api/film")]
    public class FilmController : Controller
    {
        private readonly FilmService _filmService;

        public FilmController(FilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpPost("createFilm")]
        public async Task<IActionResult> CreateFilm([FromBody] FilmCreateDTO filmCreateDTO)
        {
            var result = await _filmService.CreateFilmAsync(filmCreateDTO);

            return result ? Ok() : BadRequest();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetFilms([FromQuery] DateTime? startDate = null, [FromQuery] DateTime? finalDate = null)
        {
            return Ok(await _filmService.GetFilms(startDate, finalDate));
        }
    }
}
