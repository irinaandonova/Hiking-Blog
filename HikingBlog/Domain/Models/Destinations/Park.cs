using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
{
    public class Park : Destination
    {
        public Park(string name, User creator, string description, string imageUrl, string region, bool hasPlayground, bool isDogFriendly) : base(name, creator, description, imageUrl, region)
        {
            HasPlayground = hasPlayground;
            IsDogFriendly = isDogFriendly;
        }
        public bool HasPlayground { get; set; }
        public bool IsDogFriendly { get; set; }
    }
}
