using CinemaPlatform.Common.Dtos.PlaceStatus;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class PlaceStatusesMapper
    {
        public static PlaceStatusSessionDTO ToPlaceStatusSessionDTO(this PlaceStatus placeStatus)
        {
            return new PlaceStatusSessionDTO
            {
                IsFree = placeStatus.IsFree,
                PlaceNumber = placeStatus.Place.Number,
                RowNumber = placeStatus.Row.Number,
            };
        }
        public static ICollection<PlaceStatusSessionDTO> ToPlaceStatusSessionDTOs(this IEnumerable<PlaceStatus> placeStatus)
        {
            var list = new List<PlaceStatusSessionDTO>();
            foreach (var placeStatusItem in placeStatus)
            {
                list.Add(placeStatusItem.ToPlaceStatusSessionDTO());
            }
            return list;
        }
    }
}
