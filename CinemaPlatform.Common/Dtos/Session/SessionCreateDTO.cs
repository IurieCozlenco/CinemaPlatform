using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Session
{
    public class SessionCreateDTO
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public decimal DefaultPrice { get; set; }
        public int FilmId { get; set; }
        public int HallId { get; set; }
    }
}
