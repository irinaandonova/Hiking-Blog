namespace NatureBlog.Domain.Models
{
    public class HikingTrail : Destination
    {
        public HikingTrail(string name, User creator, string description, string imageUrl, string region, int difficulty, int hikingDuration) : base(name, creator, description, imageUrl, region)
        {
            HikingDuration = hikingDuration;
        }

        public int Difficulty { get; set; }

        public int HikingDuration { get; set; }
    }
}
