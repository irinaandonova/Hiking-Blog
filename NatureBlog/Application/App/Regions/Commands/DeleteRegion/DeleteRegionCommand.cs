using MediatR;

namespace NatureBlog.Application.App.Regions.Commands.DeleteRegion
{
    public class DeleteRegionCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }
}
