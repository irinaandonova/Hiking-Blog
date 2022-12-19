using MediatR;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Regions.GetAllRegions
{
    public class GetAllRegionsCommand : IRequest<List<Region>>
    {
    }
}
