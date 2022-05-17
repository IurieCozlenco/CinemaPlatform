﻿using CinemaPlatform.BLL.Services;
using CinemaPlatform.Common.Dtos.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace CinemaPlatform.Controllers
{
    [Route("api/ticket")]
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService filmService)
        {
            _ticketService = filmService;
        }

        [HttpPost("createTicket")]
        public async Task<IActionResult> CreateTicket([FromBody] TicketCreateDTO ticketCreateDTO)
        {
            var result = await _ticketService.CreateTicketAsync(ticketCreateDTO);

            return result ? Ok() : BadRequest();
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await _ticketService.GetAll());
        }
    }
}
