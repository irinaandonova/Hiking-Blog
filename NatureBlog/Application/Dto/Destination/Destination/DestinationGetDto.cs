namespace NatureBlog.Application.Dto.Destination.Destination
{
    public class DestinationGetDto
    {
        public int id { get; set; }

        public int creatorId { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string imageUrl { get; set; }

        public int regionId { get; set; }

        public string type { get; set; }

        public int? duration { get; set; }

        public int? difficulty { get; set; }

        public bool? isGuarded { get; set; }

        public bool? hasUmbrella { get; set; }

        public bool? hasPlayground { get; set; }

        public bool? isDogFriendly { get; set; }
    }
}
