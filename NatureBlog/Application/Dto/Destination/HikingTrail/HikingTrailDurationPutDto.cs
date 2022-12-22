using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Dto.Destination.HikingTrail
{
    public class HikingTrailDurationPutDto
    {
        public int UserId { get; set; }

        public int HikingDuration { get; set; }
    }
}
