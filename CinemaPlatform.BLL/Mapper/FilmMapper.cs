using CinemaPlatform.Common.Dtos.Film;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class FilmMapper
    {
        public static Film ToEntity(this FilmCreateDTO filmCreateDTO)
        {
            return new Film
            {
                Duration = TimeSpan.FromMinutes(filmCreateDTO.DurationMinutes),
                FinalDate = filmCreateDTO.FinalDate,
                ImageUrl = filmCreateDTO.ImageUrl,
                StartDate = filmCreateDTO.StartDate,
                Title = filmCreateDTO.Title,
                TrailerUrl = filmCreateDTO.TrailerUrl
            };
        }
        public static FilmBasicDTO ToDto(this Film film)
        {
            return new FilmBasicDTO
            {
                Id = film.Id,
                Duration = film.Duration,
                FinalDate = film.FinalDate,
                ImageUrl = film.ImageUrl,
                Sessions = film.Sessions.ToDtos(),
                StartDate = film.StartDate,
                Title = film.Title,
                TrailerUrl = film.TrailerUrl
            };
        }

        public static ICollection<FilmBasicDTO> ToDtos(this IEnumerable<Film> films)
        {
            var list = new List<FilmBasicDTO>();
            foreach (var film in films)
            {
                list.Add(film.ToDto());
            }
            return list;
        }
    }
}
