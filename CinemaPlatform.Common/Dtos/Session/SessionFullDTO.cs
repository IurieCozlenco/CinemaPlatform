using CinemaPlatform.Common.Dtos.PlaceStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Session
{
    public class SessionFullDTO
    {
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string? TitleFilm { get; set; }
        public int HallId { get; set; }
        public ICollection<PlaceStatusSessionDTO> PlacesStatusSession { get; set; } = new List<PlaceStatusSessionDTO>();
    }
}
