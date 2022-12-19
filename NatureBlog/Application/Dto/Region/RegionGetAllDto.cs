using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Region
{
    public class RegionDto
    {
        public class AllRegionsGetDto
        {
            public List<RegionGetDto> Regions { get; set; }
        }
    }
}
