using CinemaPlatform.BLL.Mapper;
using CinemaPlatform.Common.Dtos.Hall;
using CinemaPlatform.Common.Dtos.Ticket;
using CinemaPlatform.DAL.Interfaces;
using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Services
{
    public class TicketService
    {
        private readonly IGenericRepository<Ticket> _repositoryTicket;
        private readonly IGenericRepository<PlaceStatus> _repositoryPlaceStatus;

        public TicketService(
            IGenericRepository<Ticket> repositoryTicket,
            IGenericRepository<PlaceStatus> repositoryPlaceStatus)
        {
            _repositoryTicket = repositoryTicket;
            _repositoryPlaceStatus = repositoryPlaceStatus;
        }
        public async Task<bool> CreateTicketAsync(TicketCreateDTO ticketCreateDTO)
        {
            var placeStatus = await _repositoryPlaceStatus.GetAllQuery() // проверка на существуют ли такие места и сессия
                .Include(p => p.Session)
                .Include(p => p.Row)
                .Include(p => p.Place)
                .Where(p => p.Row.Number == ticketCreateDTO.RowNumber 
                    && p.Place.Number == ticketCreateDTO.PlaceNumber
                    && p.SessionId == ticketCreateDTO.SessionId)
                .FirstOrDefaultAsync();

            ticketCreateDTO.Price = placeStatus.Session.DefaultPrice;

            placeStatus.IsFree = false;

            _repositoryTicket.Add(ticketCreateDTO.ToEntity());
            _repositoryPlaceStatus.Update(placeStatus);

            await _repositoryTicket.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TicketDTO>> GetAll()
        {
            var result = await _repositoryTicket.GetAllQuery()
                .ToListAsync();

            return result.ToTicketDTOs();
        }
    }
}
