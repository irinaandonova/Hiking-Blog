using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Destination
    {
        private string Name;
        private User Creator;
        private int Difficulty;
        private string Description;
        private string ImageUrl;
        private string Region;
        private List<Comment> Comments;
        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
                Name = name;
                Creator = creator;
                Description = description;
                ImageUrl = imageUrl;
                Region = region;
        }

        public void createComment(User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            Comments.Add(comment);
        }
    }
}
