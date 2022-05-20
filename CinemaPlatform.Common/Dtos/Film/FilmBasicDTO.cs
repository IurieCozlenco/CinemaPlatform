using CinemaPlatform.Common.Dtos.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Film
{
    public class FilmBasicDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Duration)]
        public TimeSpan Duration { get; set; }
        public string? ImageUrl { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinalDate { get; set; }
        public virtual IEnumerable<SessionFilmDTO> Sessions { get; set; } = new List<SessionFilmDTO>();
    }
}
