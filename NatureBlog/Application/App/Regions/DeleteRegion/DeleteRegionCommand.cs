using MediatR;

namespace NatureBlog.Application.App.Regions.DeleteRegion
{
    public class DeleteRegionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
