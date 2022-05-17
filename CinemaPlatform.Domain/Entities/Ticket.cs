using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public virtual Session? Session { get; set; }
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public decimal Price { get; set; }
    }
}
