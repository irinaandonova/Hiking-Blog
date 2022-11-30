using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Seasides.Commands.UpdateSeaside
{
    public class UpdateSeasideCommand : IRequest<bool>
    {
        public readonly Guid Id;

        public readonly Seaside seaside;

        public User user;
    }
}
