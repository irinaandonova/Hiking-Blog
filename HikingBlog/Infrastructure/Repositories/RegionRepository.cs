using NatureBlog.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class RegionRepository : IRegion
    {
        private readonly AppDBContext _dbContext;
        public RegionRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(Region region)
        {
             await _dbContext.Regions.AddAsync(region);
        }
    }
}
