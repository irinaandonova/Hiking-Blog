namespace NatureBlog.Domain.Models
{
    public class HikingTrail : Destination
    {
        public int Difficulty { get; set; }

        public int HikingDuration { get; set; }
    }
}
