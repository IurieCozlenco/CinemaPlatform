using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Session : BaseEntity
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public int FilmId { get; set; }
        public decimal DefaultPrice { get; set; }
        public virtual Film? Film { get; set; }
        public int HallId { get; set; }
        public virtual Hall? Hall { get; set; }
        public virtual ICollection<PlaceStatus> PlaceStatuses { get; set; } = new List<PlaceStatus>();
    }
}
