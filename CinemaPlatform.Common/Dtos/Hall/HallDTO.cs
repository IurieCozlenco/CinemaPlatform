using CinemaPlatform.Common.Dtos.Row;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Hall
{
    public class HallDTO
    {
        public int HallId { get; set; }
        public IEnumerable<RowDTO> Rows { get; set; } = new List<RowDTO>();
    }
}
