using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Destination.Commands.DeleteDestination
{
    internal class DeleteDestinationCommand: IRequest<bool>
    {
        public readonly Guid Id;
    }
}
