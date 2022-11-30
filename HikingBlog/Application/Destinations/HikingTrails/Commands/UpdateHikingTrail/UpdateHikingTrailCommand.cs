using MediatR;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.HikingTrails.Commands.UpdateHikingTrail
{
    internal class UpdateHikingTrailCommand: IRequest<bool>
    {
        public readonly Guid Id;

        public HikingTrail hikingTrail;

        public User user;
    }
}
