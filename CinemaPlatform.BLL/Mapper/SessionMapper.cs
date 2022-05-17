using CinemaPlatform.Common.Dtos.Session;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class SessionMapper
    {
        public static Session ToEntity(this SessionCreateDTO sessionCreateDTO)
        {
            return new Session
            {
                DefaultPrice = sessionCreateDTO.DefaultPrice,
                Date = sessionCreateDTO.Date,
                FilmId = sessionCreateDTO.FilmId,
                HallId = sessionCreateDTO.HallId,
                Time = sessionCreateDTO.Time,
            };
        }
        public static SessionBasicDTO ToSessionBasicDTO(this Session session)
        {
            return new SessionBasicDTO
            {
                SessionId = session.Id,
                Date = session.Date,
                HallId = session.HallId,
                Time = session.Time,
                TitleFilm = session.Film.Title
            };
        }

        public static SessionFullDTO ToSessionFullDTO(this Session session)
        {
            return new SessionFullDTO
            {
                Date = session.Date,
                HallId = session.HallId,
                Time = session.Time,
                TitleFilm = session.Film.Title,
                PlacesStatusSession = session.PlaceStatuses.ToPlaceStatusSessionDTOs()
            };
        }

        public static ICollection<SessionBasicDTO> ToSessionBasicDTOs(this IEnumerable<Session> sessions)
        {
            var list = new List<SessionBasicDTO>();
            foreach(var session in sessions)
            {
                list.Add(session.ToSessionBasicDTO());
            }
            return list;
        }

        public static SessionFilmDTO ToSessionFilmDTO(this Session session)
        {
            return new SessionFilmDTO
            {
                Date = session.Date,
                HallId = session.HallId,
                Time = session.Time,
            };
        }

        public static ICollection<SessionFilmDTO> ToDtos(this IEnumerable<Session> sessions)
        {
            var list = new List<SessionFilmDTO>();
            foreach (var session in sessions)
            {
                list.Add(session.ToSessionFilmDTO());
            }
            return list;
        }
    }
}
