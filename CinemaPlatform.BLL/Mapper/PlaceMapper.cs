using CinemaPlatform.Common.Dtos.Place;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class PlaceMapper
    {
        public static PlaceDTO ToDto(this Place place)
        {
            return new PlaceDTO
            { 
                PlaceNumber = place.Number,
            };
        }

        public static ICollection<PlaceDTO> ToDtos(this IEnumerable<Place> places)
        {
            var list = new List<PlaceDTO>();
            foreach (var p in places)
            {
                list.Add(p.ToDto());
            }
            return list;
        }
    }
}
