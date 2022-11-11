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
        private Dictionary<string, Comment> Comments = new Dictionary<string, Comment> {};
        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
                Name = name;
                Creator = creator;
                Description = description;
                ImageUrl = imageUrl;
                Region = region;
        }

        public void CreateComment(User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            string id = comment.Id;
            Comments.Add(id, comment);
        }
        public void ShowComments()
        {
            foreach(KeyValuePair<string, Comment> comment in Comments)
            {
                Console.WriteLine(comment.Value.Text);
            }
        }
    }
}
