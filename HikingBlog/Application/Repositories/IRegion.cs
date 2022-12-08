using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Repositories
{
    public interface IRegion
    {
        public Task Add(Region region);
    }
}
