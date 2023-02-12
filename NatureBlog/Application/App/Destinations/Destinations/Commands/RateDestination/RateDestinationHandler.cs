using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;
using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Exceptions;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{

    public class RateDestinationHandler : IRequestHandler<RateDestinationCommand, decimal>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RateDestinationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<decimal> Handle(RateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = _unitOfWork.UserRepository.GetUser(command.UserId);
                if (user is null)
                    throw new UserNotFoundException("No user with given id!");

                Destination? destination = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                if (destination is null)
                    throw new DestinationNotFoundException("No destination found with given id!");

                await _unitOfWork.DestinationRepository.RateDestination(command.DestinationId, command.RatingValue, command.UserId);
                await _unitOfWork.Save();

                decimal currentRating = _unitOfWork.DestinationRepository.CalcRatings(destination);
                return currentRating;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the RateDestination Method! " + ex.Message);
                throw ex;
            }
        }
    }
}
