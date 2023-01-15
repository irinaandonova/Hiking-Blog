using MediatR;

namespace NatureBlog.Application.Destinations.Seasides.Commands.UpdateSeaside
{
    public class UpdateSeasideCommand : IRequest<bool?>
    {
        public int DestinationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public bool IsGuarded { get; set; }

        public bool OffersUmbrella { get; set; }

        public int UserId { get; set; }
    }
}
