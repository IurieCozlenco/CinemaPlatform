using CinemaPlatform.BLL.Services;
using CinemaPlatform.Common.Dtos.Session;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Controllers
{
    [Route("api/session")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public SessionController(SessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost("createSession")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateSession([FromBody] SessionCreateDTO sessionCreateDTO)
        {
            var result = await _sessionService.CreateSessionAsync(sessionCreateDTO);

            return result ? Ok() : BadRequest();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetSession()
        {
            return Ok(await _sessionService.GetSessions());
        }
        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GetSessionInfo(int sessionId)
        {
            var result = await _sessionService.GetSessionInfo(sessionId);

            return result is not null ? Ok(result) : BadRequest();
        }
    }
}
