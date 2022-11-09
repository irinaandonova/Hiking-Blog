using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Park: Destination
    {
        private bool HasPlayground;
        private bool IsDogFriendlyl;
        public Park(string name, string creator, string description, string imageUrl, string region, bool hasPlayground, bool isDogFriendlyl) : base(name, creator, description, imageUrl, region)
        {
            HasPlayground = hasPlayground;
            IsDogFriendlyl = isDogFriendlyl;
        }
    }
}
