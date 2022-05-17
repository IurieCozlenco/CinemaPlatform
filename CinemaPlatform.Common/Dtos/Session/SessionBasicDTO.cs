using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Session
{
    public class SessionBasicDTO
    {
        public int SessionId { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? TitleFilm { get; set; }
        public int HallId { get; set; }
    }
}
