using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace HikingBlog.Extensions
{
    internal static class ModelExtensions
    {
        public staticvoid CreateComment(this Destination destination, User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            string id = comment.Id;
            destinations.Comments.Add(id, comment);
        }
        public void ShowComments()
        {
            foreach (KeyValuePair<string, Comment> comment in Comments)
            {
                Console.WriteLine(comment.Value.Text);
            }
        }
        public static void AddUmbrellaPrices(this Seaside seaside, double umbrellaPrice)
        {
            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;
        }
        public static void ShowUmbrellaPrices(this Seaside seaside)
        {
            if (seaside.OffersUmbrella)
                Console.WriteLine($"An umbrella could be rented for {seaside.UmbrellaPrice:C}");
            else
                Console.WriteLine("This destination doesn't offer umbrellas");
        }
    }
}
