using AutoMapper;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Domain.Models;

namespace NatureBlog.Presenatation.Profiles
{
    public class HikingTrailProfile : Profile
    {
        public HikingTrailProfile()
        {
            CreateMap<HikingTrailPostDto, HikingTrail>();
            CreateMap<HikingTrail, HikingTrailGetDto>()
                .ForMember(ht => ht.RatingScore, options => options.MapFrom((ht) => CalcRatings(ht)));
        }

        private decimal CalcRatings(HikingTrail hikingTrail)
        {
            int allRatings = 0;
            if(hikingTrail.Ratings.Count == 0)
                return 2.5M;
            foreach(var rating in hikingTrail.Ratings)
            {
                allRatings += rating.RatingValue;
            }
            decimal ratingScore = (decimal)allRatings / hikingTrail.Ratings.Count;

            return ratingScore;
        }
    }
}
