using MediatR;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.App.Destinations.Destinations.Queries.GetDestination
{
    internal class GetDestinationCommand : IRequest<Destination>
    {
        public readonly Guid Id;
    }
}
