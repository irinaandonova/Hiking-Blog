using AutoMapper;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Domain.Models;

namespace NatureBlog.Presenatation.Profiles
{
    public class ParkProfile : Profile
    {
        public ParkProfile()
        {
            CreateMap<ParkPostDto, Park>();
            CreateMap<Park, ParkGetDto>()
                .ForMember(p => p.RatingScore, options => options.MapFrom((p) => CalcRatings(p)));
        }

        private decimal CalcRatings(Park park)
        {
            int allRatings = 0;

            foreach (var rating in park.Ratings)
            {
                allRatings += rating.RatingValue;
            }
            decimal ratingScore = (decimal)allRatings / park.Ratings.Count;

            return ratingScore;
        }

    }
}
