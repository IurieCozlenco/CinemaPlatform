using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Place : BaseEntity
    {
        public int RowId { get; set; }
        public int Number { get; set; }
        public virtual ICollection<PlaceStatus> PlaceStatuses { get; set; } = new List<PlaceStatus>();

    }
}
