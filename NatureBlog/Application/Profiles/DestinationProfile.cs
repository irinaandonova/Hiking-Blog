using AutoMapper;
using Microsoft.Extensions.Options;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<Destination, DestinationGetDto>()
                .ForMember(d => d.RatingScore, options => options.MapFrom((d) => CalcRatings(d)));
            CreateMap<HikingTrail, DestinationGetDto>();
            CreateMap<Seaside, DestinationGetDto>();
            CreateMap<Park, DestinationGetDto>();
        }
        
        private decimal CalcRatings(Destination destination)
        {
            int allRatings = 0;

            if (destination.Ratings.Count == 0)
                return 2.5M;

            foreach (var rating in destination.Ratings)
            {
                allRatings += rating.RatingValue;
            }
            decimal ratingScore = (decimal)allRatings / destination.Ratings.Count;

            return ratingScore;
        }
    }
}

