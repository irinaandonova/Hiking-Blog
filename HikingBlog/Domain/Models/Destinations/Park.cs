namespace NatureBlog.Domain.Models
{
    public class Park : Destination
    {
        public bool HasPlayground { get; set; }
        
        public bool IsDogFriendly { get; set; }
    }
}
