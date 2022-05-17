using CinemaPlatform.Common.Dtos.Place;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.Common.Dtos.Row
{
    public class RowDTO
    {
        public IEnumerable<PlaceDTO> Places { get; set; } = new List<PlaceDTO>();
    }
}
