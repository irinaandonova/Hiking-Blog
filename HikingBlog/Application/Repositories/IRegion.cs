using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IRegion
    {
        public Task Add(Region region);
    }
}
