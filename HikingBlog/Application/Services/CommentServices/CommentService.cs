using NatureBlog.Exceptions;
using NatureBlog.Models;
using NatureBlog.Services.CommentServices.Interfaces;
using NatureBlog.Services.DestinationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace NatureBlog.Services.CommentServices
{
    internal class CommentService : ICommentService
    {
        public DestinationService destinationService = new DestinationService();
        private readonly Dictionary<Guid, Destination> destinations;
        private readonly Dictionary<Guid, Comment> comments;

        public void CreateComment(Guid destinationId, User creator, string text, string mainCommentId)
        {
            try
            {
                Destination destination = destinationService.GetDestination(destinationId);

                if (mainCommentId == null)
                {
                    Comment comment = new Comment(creator, text, destination);
                    destination.Comments.Add(comment.Id, comment);
                }
                else
                {
                    Reply comment = new Reply(creator, text, destination, mainCommentId);
                    destination.Comments.Add(comment.Id, comment);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
            }
        }

        public void DeleteComment(Guid destinationId, User creator, Guid commentId)
        {
            try
            {
                Destination destination = destinationService.GetDestination(destinationId);

                if (!destination.Comments.ContainsKey(commentId))
                    throw new CommentNotFoundException("No comment found with the given id!");
                if (destination.Comments[commentId].Creator != creator)
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");
                destination.Comments.Remove(commentId);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Exception in the DeleteComment Method! Insert all values!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
            }
        }

        public void EditComment(Guid destinationId, User creator, Guid commentId, string text)
        {
            try
            {
                Destination destination = destinationService.GetDestination(destinationId);

                if (!destination.Comments.ContainsKey(commentId))
                    throw new CommentNotFoundException("No comment found with the given id!");
                if (destination.Comments[commentId].Creator == creator)
                    destination.Comments[commentId].Text = text;
                else
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");

            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Exception in the DeleteComment Method! Insert all values!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
            }
        }
    }
}
