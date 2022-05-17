using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Ticket
{
    public class TicketCreateDTO
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public decimal Price { get; set; }
    }
}
