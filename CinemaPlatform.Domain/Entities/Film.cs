using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Domain.Entities
{
    public class Film : BaseEntity
    {
        public string? Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string? ImageUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public virtual ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
