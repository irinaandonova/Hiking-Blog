using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Park : Destination
    {
        public Park(string name, User creator, string description, string imageUrl, string region, bool hasPlayground, bool isDogFriendlyl) : base(name, creator, description, imageUrl, region)
        {
            HasPlayground = hasPlayground;
            IsDogFriendlyl = isDogFriendlyl;
        }
        public bool HasPlayground { get; set; }
        public bool IsDogFriendlyl { get; set; }
    }
}
