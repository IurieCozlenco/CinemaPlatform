using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Row : BaseEntity
    {
        public int HallId { get; set; }
        public int Number { get; set; }
        public virtual ICollection<PlaceStatus> PlaceStatuses { get; set; } = new List<PlaceStatus>();
        public virtual ICollection<Place> Places { get; set; } = new List<Place>();
    }
}
