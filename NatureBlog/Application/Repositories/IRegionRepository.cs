using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IRegionRepository
    {
        public Task Add(Region region);

        public Task<ICollection<Region>> GetAll();

    }
}
