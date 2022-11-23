using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    internal class CommentService
    {
        public void CreateComment(Destination destination, User creator, string text, string? mainCommentId)
        {
            if (mainCommentId == null)
            {
                Comment comment = new Comment(creator, text);
                string id = comment.Id;
                destination.AddComment(id, comment);
            }
            else
            {
                Reply reply = new Reply(creator, text, mainCommentId);
                destination.AddComment(reply.Id, reply);
            }
        }

        public void DeleteComment(Destination destination, User creator, string id)
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

        public void EditComment(Destination destination, User creator, string id, string text)
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
