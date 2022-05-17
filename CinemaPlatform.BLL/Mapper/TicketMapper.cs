using CinemaPlatform.Common.Dtos.Ticket;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class TicketMapper
    {
        public static Ticket ToEntity(this TicketCreateDTO ticketCreateDTO)
        {
            return new Ticket
            {
                SessionId = ticketCreateDTO.SessionId,
                Price = ticketCreateDTO.Price,
                PlaceNumber = ticketCreateDTO.PlaceNumber,
                RowNumber = ticketCreateDTO.RowNumber,
                UserId = ticketCreateDTO.UserId,
            };
        }

        public static TicketDTO ToTicketDTO(this Ticket ticket)
        {
            return new TicketDTO
            {
                SessionId = ticket.SessionId,
                Price = ticket.Price,
                PlaceNumber = ticket.PlaceNumber,
                RowNumber = ticket.RowNumber,
                UserId = ticket.UserId
            };
        }

        public static ICollection<TicketDTO> ToTicketDTOs(this IEnumerable<Ticket> tickets)
        {
            var list = new List<TicketDTO>();
            foreach (var ticket in tickets)
            {
                list.Add(ticket.ToTicketDTO());
            }
            return list;
        }
    }
}
