using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NatureBlog.Services
{
    internal class CommentService
    {
        public void CreateComment(Destination destination, User creator, string text, string? mainCommentId)
        {
            if (mainCommentId == null)
            {
                Comment comment = new Comment(creator, text, destination);
                string id = comment.Id;
                destination.Comments.Add(id, comment);
            }
            else
            {
                Reply reply = new Reply(creator, text, destination, mainCommentId);
                destination.Comments.Add(reply.Id, reply);
            }
        }

        public void DeleteComment(Destination destination, User creator, string id)
        {
            try
            {
                if (!destination.Comments.ContainsKey(id))
                    throw new InvalidOperationException("Current user isn't the creator of the comment!");
                destination.Comments.Remove(id);
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

        public void EditComment(Destination destination, User creator, string id, string text)
        {
            try
            {
                if (destination.Comments[id].Creator == creator)
                    destination.Comments[id].Text = text;
                else
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");

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
