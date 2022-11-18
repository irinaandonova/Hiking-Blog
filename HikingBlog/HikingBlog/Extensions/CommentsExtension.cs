using HikingBlog.Exceptions;
using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace HikingBlog.Extensions
{
    internal static class CommentsExtension
    {
        public static void CreateComment(this Destination destination, User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            string id = comment.Id;
            destination.AddComment(id, comment);
        }

        public static void DeleteComment(this Destination destination, User creator, string id)
        {
            try
            {
                if (!destination.CompareUser(id, creator))
                    throw new InvalidOperationException("Current user isn't the creator of the comment!");
                destination.RemoveComment(id);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No comment found with given id!");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Insert all values!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void EditComment(this Destination destination, User creator, string id, string text)
        {
            try
            {
                if (!destination.CompareUser(id, creator))
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");
                destination.EditComment(id, text);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine($"Insert all values!");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("No comment found with given id!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
