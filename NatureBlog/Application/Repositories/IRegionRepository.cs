using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IRegionRepository
    {
        public Region GetRegion(int regionId);

        public Task Add(Region region);

        public Task<List<Region>> GetAll();

        public bool Delete(int regionId);

    }
}
