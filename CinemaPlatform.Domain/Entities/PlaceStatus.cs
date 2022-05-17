using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class PlaceStatus : BaseEntity
    {
        public int RowId { get; set; }
        public virtual Row? Row { get; set; }
        public int PlaceId { get; set; }
        public virtual Place? Place  { get; set; }
        public bool IsFree { get; set; } = true;
        public int SessionId { get; set; }
        public virtual Session? Session { get; set; }
    }
}
