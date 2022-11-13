using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    internal class Rating
    {
        public Rating(int ratingValue, User user)
        {
            if (ratingValue <= 0 || ratingValue > 5)
                throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
            if (user == null)
                throw new ArgumentNullException("User field is missing!");

            RatingValue = ratingValue;
            this.User = user;
        }
        int RatingValue { get; set; }
        public User User { get; set; }
    }
}
