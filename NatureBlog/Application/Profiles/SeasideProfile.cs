using AutoMapper;
using NatureBlog.Application.Dto.Destination.Seaside;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class SeasideProfile: Profile
    {
        public SeasideProfile() 
        {
            CreateMap<SeasidePostDto, Seaside>();
            CreateMap<Seaside, SeasideGetDto>()
                .ForMember(s => s.RatingScore, options => options.MapFrom((s) => CalcRatings(s)));
        }

        private decimal CalcRatings(Seaside seaside)
        {
            int allRatings = 0;
            if (seaside.Ratings.Count == 0)
                return 2.5M;

            foreach (var rating in seaside.Ratings)
            {
                allRatings += rating.RatingValue;
            }
            decimal ratingScore = (decimal)allRatings / seaside.Ratings.Count;

            return ratingScore;
        }
    }
}
