using MediatR;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails
{
    public class FilterHikingTrailsQuery : IRequest<List<HikingTrail>>
    {
        public int difficulty;
    }
}
