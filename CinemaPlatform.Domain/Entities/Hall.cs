using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Hall : BaseEntity
    {
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
        public virtual ICollection<Row> Rows { get; set; } = new List<Row>();
    }
}
