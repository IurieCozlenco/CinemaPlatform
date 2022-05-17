using CinemaPlatform.Common.Dtos.Hall;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class HallMapper
    {
        public static Hall ToEntity(this HallCreateDTO hallCreateDTO)
        {
            return new Hall
            {
                Rows = hallCreateDTO.Rows.ToEntities()
            };
        }

        public static HallDTO ToDto(this Hall hall)
        {
            return new HallDTO
            {
                HallId = hall.Id,
                Rows = hall.Rows.ToDtos()
            };
        }

        public static ICollection<HallDTO> ToDtos(this IEnumerable<Hall> halls)
        {
            var list = new List<HallDTO>();
            foreach (var hall in halls)
            {
                list.Add(hall.ToDto());
            }
            return list;
        }
    }
}
