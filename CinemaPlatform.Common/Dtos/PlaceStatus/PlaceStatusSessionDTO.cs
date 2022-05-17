using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.PlaceStatus
{
    public class PlaceStatusSessionDTO
    {
        public int RowNumber { get; set; }
        public int PlaceNumber { get; set; }
        public bool IsFree { get; set; }
    }
}
