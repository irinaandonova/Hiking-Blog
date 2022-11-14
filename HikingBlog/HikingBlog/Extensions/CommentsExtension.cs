using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Extensions
{
    internal static class CommentsExtension
    {
        public static void CreateComment(this Destination destination, User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            string id = comment.Id;
            destination.Comments.Add(id, comment);
        }

        public static void ShowComments(this Destination destination)
        {
            foreach (KeyValuePair<string, Comment> comment in destination.Comments)
            {
                Console.WriteLine(comment.Value.Text);
            }
        }
    }
}
