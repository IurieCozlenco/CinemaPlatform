using CinemaPlatform.Common.Dtos.Hall;
using CinemaPlatform.Common.Dtos.Row;
using CinemaPlatform.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.BLL.Mapper
{
    public static class RowMapper
    {
        public static Row ToEntity(this RowCreate rowCreate, int rowNumber)
        {
            var places = new List<Place>();

            for (int i = 0; i < rowCreate.PlacesCount; i++)
            {
                places.Add(new Place { Number = (i + 1) });
            }

            return new Row
            {
                Number = rowNumber,
                Places = places
            };
        }

        public static ICollection<Row> ToEntities(this IEnumerable<RowCreate> rowCreates)
        {
            int i = 1;
            var list = new List<Row>();
            foreach (var rowCreate in rowCreates)
            {
                list.Add(ToEntity(rowCreate, i++));
            }
            return list;
        }

        public static RowDTO ToDto(this Row row)
        {
            return new RowDTO
            {
                Places = row.Places.ToDtos()
            };
        }

        public static IEnumerable<RowDTO> ToDtos(this IEnumerable<Row> rows)
        {
            var list = new List<RowDTO>();
            foreach (var row in rows)
            {
                list.Add(row.ToDto());
            }
            return list;
        }
    }
}
